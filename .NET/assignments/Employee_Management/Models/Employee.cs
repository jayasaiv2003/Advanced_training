using System;
using System.Collections.Generic;

namespace Employee_Management.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string FullName { get; set; } = null!;

    public string Department { get; set; } = null!;

    public decimal Salary { get; set; }

    public string? Email { get; set; }
}
