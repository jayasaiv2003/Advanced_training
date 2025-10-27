using LINQ_assignments;

//Employee Data
var employees = new List<Employee>
            {
                new Employee{ Id=1, Name="Ravi", Department="IT", Salary=85000, Experience=5, Location="Bangalore"},
                new Employee{ Id=2, Name="Priya", Department="HR", Salary=52000, Experience=4, Location="Pune"},
                new Employee{ Id=3, Name="Kiran", Department="Finance", Salary=73000, Experience=6, Location="Hyderabad"},
                new Employee{ Id=4, Name="Asha", Department="IT", Salary=95000, Experience=8, Location="Bangalore"},
                new Employee{ Id=5, Name="Vijay", Department="Marketing", Salary=68000, Experience=5, Location="Mumbai"},
                new Employee{ Id=6, Name="Deepa", Department="HR", Salary=61000, Experience=7, Location="Delhi"},
                new Employee{ Id=7, Name="Arjun", Department="Finance", Salary=82000, Experience=9, Location="Bangalore"},
                new Employee{ Id=8, Name="Sneha", Department="IT", Salary=78000, Experience=4, Location="Pune"},
                new Employee{ Id=9, Name="Rohit", Department="Marketing", Salary=90000, Experience=10, Location="Delhi"},
                new Employee{ Id=10, Name="Meena", Department="Finance", Salary=66000, Experience=3, Location="Mumbai"}
            };

Console.WriteLine("-------------------------------------------------");
//1.Display all employees working in the IT department.

var allinit = employees.Where(e => e.Department=="IT");
foreach(var emp in allinit)
{
    Console.WriteLine(emp.Name);
}

Console.WriteLine("-------------------------------------------------");
//2.List names and salaries of employees who earn more than 70,000.


var above70k = employees.Where(e => e.Salary > 70000)
                        .Select(e=> $"{e.Name} --{e.Salary}");
foreach(var emp in above70k)
{
       Console.WriteLine(emp);
}
Console.WriteLine("-------------------------------------------------");

//3.Find all employees located in Bangalore.
var inbangalore = employees.Where(e => e.Location=="Bangalore");
Console.WriteLine("Employees in Bangalore:");
foreach(var emp in inbangalore)
{
    Console.WriteLine(emp.Name);
}

Console.WriteLine("-------------------------------------------------");
//4.Display employees having more than 5 years of experience.
var above5=employees.Where(e => e.Experience > 5);
foreach(var emp in above5)
    {
    Console.WriteLine(emp.Name);
}   

Console.WriteLine("-------------------------------------------------");

//5.Show names of employees and their salaries in ascending order of salary.

var employeeinasc = employees.OrderBy(e=>e.Salary)
                            .Select(e => $"{e.Name}--{e.Salary}");
foreach(var emp in employeeinasc)
{
       Console.WriteLine(emp);
}


var groupbylocation = employees.GroupBy(e => e.Location)
                               .Select(e => new
                               {
                                   Location = e.Key,
                                   Count = e.Count()
                               });


// 6.Group employees by location and count how many employees are in each location.
Console.WriteLine("-------------------------------------------------");
foreach (var loc in groupbylocation)
{
    Console.WriteLine($"{loc.Location}--{loc.Count}");
}

//7.Display employees whose salary is above the average salary.
Console.WriteLine("-------------------------------------------------");
var avgsalary=employees.Average(e => e.Salary);
var aboveavgsalary = employees.Where(e => e.Salary > avgsalary);

foreach(var emp in aboveavgsalary)
{
    Console.WriteLine(emp.Name);
}


Console.WriteLine("-------------------------------------------------");

//8.Show top 3 highest-paid employees.

var top3salary = employees.OrderByDescending(e=>e.Salary)
                          .Take(3);

foreach(var emp in top3salary)
    {
    Console.WriteLine($"{emp.Name}--{emp.Salary}");
}




