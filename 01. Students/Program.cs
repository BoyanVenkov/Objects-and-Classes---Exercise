int count = int.Parse(Console.ReadLine());

List<Student> students = new List<Student>();

for (int i = 1; i<= count; i++)
{
    string[] studentInfo = Console.ReadLine().Split().ToArray();
    string firstName = studentInfo[0];
    string lastName = studentInfo[1];
    double grade = double.Parse(studentInfo[2]);

    Student currentStudent = new Student(firstName, lastName, grade);

    students.Add(currentStudent);
}

List<Student> sortedStudents = students.OrderByDescending(s => s.Grade).ToList();

foreach (Student student in sortedStudents)
{
    Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:f2}");

}

class Student
{
    public Student(string firstName, string lastName, double grade)
    { 
        FirstName = firstName;
        LastName = lastName;
        Grade = grade;
    }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public double Grade { get; set; }
}

