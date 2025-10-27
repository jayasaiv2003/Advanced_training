using Linq_student_tasks;

//Student Data

var students = new List<Student>
            {
                new Student{ Id=1, Name="Asha", Course="C#", Marks=92, City="Bangalore"},
                new Student{ Id=2, Name="Ravi", Course="Java", Marks=85, City="Pune"},
                new Student{ Id=3, Name="Sneha", Course="Python", Marks=78, City="Hyderabad"},
                new Student{ Id=4, Name="Kiran", Course="C#", Marks=88, City="Delhi"},
                new Student{ Id=5, Name="Meena", Course="Python", Marks=95, City="Bangalore"},
                new Student{ Id=6, Name="Vijay", Course="C#", Marks=82, City="Chennai"},
                new Student{ Id=7, Name="Deepa", Course="Java", Marks=91, City="Mumbai"},
                new Student{ Id=8, Name="Arjun", Course="Python", Marks=89, City="Hyderabad"},
                new Student{ Id=9, Name="Priya", Course="C#", Marks=97, City="Pune"},
                new Student{ Id=10, Name="Rohit", Course="Java", Marks=74, City="Delhi"}
            };

//1.Find the highest scorer in each course.

var highscorer = students.GroupBy(s => s.Course)
                        .Select(g => new
                        {
                            Course = g.Key,
                            TopStudent = g.OrderByDescending(s => s.Marks).First()
                        });
foreach (var entry in highscorer)
    {
    Console.WriteLine($"Course: {entry.Course}, Top Student: {entry.TopStudent.Name}, Marks: {entry.TopStudent.Marks}");
}

Console.WriteLine("--------------------------------------------------");

//2.Display average marks of all students city-wise.

var avgmarks = students.GroupBy(s => s.City)
                       .Select(g => new
                       {
                           City = g.Key,
                           AverageMarks = g.Average(s => s.Marks)
                       });
foreach (var entry in avgmarks)
    {
    Console.WriteLine($"City: {entry.City}, Average Marks: {entry.AverageMarks}");
}

Console.WriteLine("--------------------------------------------------");

//3.Display names and marks of students ranked by marks.

var rankedStudents = students.OrderByDescending(s => s.Marks);

    foreach (var student in rankedStudents)
    {
    Console.WriteLine($"Name: {student.Name}, Marks: {student.Marks}");
    }
