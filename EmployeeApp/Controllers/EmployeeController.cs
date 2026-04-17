using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

public class EmployeeController : Controller
{
    private readonly IConfiguration _config;

    public EmployeeController(IConfiguration config)
    {
        _config = config;
    }

    // ================= GRID (READ) =================
    public IActionResult Index()
    {
        using (IDbConnection db = new SqlConnection(
            _config.GetConnectionString("DBCS")))
        {
            var list = db.Query<Employee>(
                "sp_GetEmployees",
                commandType: CommandType.StoredProcedure
            ).ToList();

            return View(list);
        }
    }

    // ================= CREATE (GET) =================
    public IActionResult Create()
    {
        return View();
    }

    // ================= CREATE (POST) =================
    [HttpPost]
    public IActionResult Create(Employee emp)
    {
        if (!ModelState.IsValid)
            return View(emp);

        using (IDbConnection db = new SqlConnection(_config.GetConnectionString("DBCS")))
        {
            db.Execute("sp_AddEmployee",
                new
                {
                    emp.FirstName,
                    emp.LastName,
                    emp.DOB,
                    emp.Country,
                    emp.State,
                    emp.City,
                    emp.Qualification,
                    emp.Email,
                    emp.Phone
                },
                commandType: CommandType.StoredProcedure);
        }

        return RedirectToAction("Index");
    }

    // ================= EDIT (GET) =================
    public IActionResult Edit(int id)
    {
        using (IDbConnection db = new SqlConnection(_config.GetConnectionString("DBCS")))
        {
            var emp = db.QueryFirstOrDefault<Employee>(
                "SELECT * FROM Employees WHERE Id=@Id",
                new { Id = id });

            return View(emp);
        }
    }

    // ================= EDIT (POST) =================
    [HttpPost]
    public IActionResult Edit(Employee emp)
    {
        if (!ModelState.IsValid)
            return View(emp);

        using (IDbConnection db = new SqlConnection(_config.GetConnectionString("DBCS")))
        {
            db.Execute("sp_UpdateEmployee",
                new
                {
                    emp.Id,
                    emp.FirstName,
                    emp.LastName,
                    emp.DOB,
                    emp.Country,
                    emp.State,
                    emp.City,
                    emp.Qualification,
                    emp.Email,
                    emp.Phone
                },
                commandType: CommandType.StoredProcedure);
        }

        return RedirectToAction("Index");
    }

    // ================= DELETE =================
    public IActionResult Delete(int id)
    {
        using (IDbConnection db = new SqlConnection(_config.GetConnectionString("DBCS")))
        {
            db.Execute("sp_DeleteEmployee",
                new { Id = id },
                commandType: CommandType.StoredProcedure);
        }

        return RedirectToAction("Index");
    }
}