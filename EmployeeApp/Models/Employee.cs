using System;
using System.ComponentModel.DataAnnotations;

public class Employee
{
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; }

    public string LastName { get; set; }

    [DataType(DataType.Date)]
    public DateTime DOB { get; set; }

    public string Country { get; set; }
    public string State { get; set; }
    public string City { get; set; }

    public string Qualification { get; set; }

    [EmailAddress]
    public string Email { get; set; }

    [Phone]
    public string Phone { get; set; }
}