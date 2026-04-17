# 🧑‍💼 Employee Management System (ASP.NET Core MVC + Dapper)

## 📌 Project Description

This is a simple **Employee Management System** built using **ASP.NET Core MVC**, **SQL Server**, and **Dapper ORM**.
The application allows users to perform full **CRUD operations (Create, Read, Update, Delete)** on employee records.

---

## 🚀 Features

* Add new employee
* View employee list in grid format
* Edit employee details
* Delete employee records
* Uses stored procedures for database operations
* Dapper ORM for fast data access
* Basic form validation

---

## 🛠️ Technologies Used

* ASP.NET Core MVC
* C#
* SQL Server
* Dapper ORM
* Razor Views (HTML)

---

## 🗄️ Database Setup

### Step 1: Create Database

```sql
CREATE DATABASE EmployeeDb;
```

### Step 2: Use Database

```sql
USE EmployeeDb;
```

### Step 3: Create Table

```sql
CREATE TABLE employees (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    DOB DATE,
    Country NVARCHAR(50),
    State NVARCHAR(50),
    City NVARCHAR(50),
    Qualification NVARCHAR(100),
    Email NVARCHAR(100),
    Phone NVARCHAR(20)
);
```

---

## ⚙️ Stored Procedures

### 1. Get All Employees

```sql
CREATE PROC sp_GetEmployees
AS
BEGIN
    SELECT * FROM employees
END
```

### 2. Insert Employee

```sql
CREATE PROC sp_AddEmployee
@FirstName NVARCHAR(50),
@LastName NVARCHAR(50),
@DOB DATE,
@Country NVARCHAR(50),
@State NVARCHAR(50),
@City NVARCHAR(50),
@Qualification NVARCHAR(100),
@Email NVARCHAR(100),
@Phone NVARCHAR(20)
AS
BEGIN
    INSERT INTO employees
    VALUES (@FirstName,@LastName,@DOB,@Country,@State,@City,@Qualification,@Email,@Phone)
END
```

### 3. Update Employee

```sql
CREATE PROC sp_UpdateEmployee
@Id INT,
@FirstName NVARCHAR(50),
@LastName NVARCHAR(50),
@DOB DATE,
@Country NVARCHAR(50),
@State NVARCHAR(50),
@City NVARCHAR(50),
@Qualification NVARCHAR(100),
@Email NVARCHAR(100),
@Phone NVARCHAR(20)
AS
BEGIN
    UPDATE employees
    SET
        FirstName=@FirstName,
        LastName=@LastName,
        DOB=@DOB,
        Country=@Country,
        State=@State,
        City=@City,
        Qualification=@Qualification,
        Email=@Email,
        Phone=@Phone
    WHERE Id=@Id
END
```

### 4. Delete Employee

```sql
CREATE PROC sp_DeleteEmployee
@Id INT
AS
BEGIN
    DELETE FROM employees WHERE Id=@Id
END
```

---

## 🔌 Connection String

Update in `appsettings.json`:

```json
"ConnectionStrings": {
  "DBCS": "Data Source=.;Initial Catalog=EmployeeDb;Integrated Security=True"
}
```

---

## ▶️ How to Run the Project

1. Clone the repository:

```bash
git clone https://github.com/yourusername/EmployeeManagementSystem.git
```

2. Open the solution in **Visual Studio**

3. Install NuGet package:

```bash
Install-Package Dapper
```

4. Open SQL Server and run:

   * Database creation script
   * Table script
   * Stored procedures

5. Update connection string in `appsettings.json`

6. Run the project using **IIS Express**

7. Open in browser:

```
http://localhost:xxxx/Employee
```

---

## 📁 Project Structure

* Controllers → EmployeeController.cs
* Models → Employee.cs
* Views → Employee (Index, Create, Edit)

---

## 🎯 Functional Overview

| Operation | Description           |
| --------- | --------------------- |
| Create    | Add new employee      |
| Read      | Display employee list |
| Update    | Edit employee details |
| Delete    | Remove employee       |

---

## 👨‍💻 Author

**AQUIB RAZA**

---

## 📌 Notes

* Make sure SQL Server is running
* Ensure database name matches connection string
* All stored procedures must be created before running the project

---
