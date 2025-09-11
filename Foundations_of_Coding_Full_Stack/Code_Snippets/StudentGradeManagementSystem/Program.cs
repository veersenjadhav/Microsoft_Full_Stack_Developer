using System;
using System.Collections.ObjectModel;

class Student
{
    public int StudentId { get; set; }

    public string? StudentName { get; set; }

    Collection<Report> ColReport = new Collection<Report>();

    public void InsertStudent(int aintStudentId, string? lstrStudentName)
    {
        this.StudentId = aintStudentId;
        this.StudentName = lstrStudentName;
    }
}

class Report
{
    public string? SubjectName { get; set; }

    public double Grades { get; set; }
}

class StudentGradeManagement
{
    public static void Main(string[] args)
    {
        Collection<Student> ColStudent = new Collection<Student>();

        while (true)
        {
            Console.WriteLine("\n 1: Add Student \n 2: Display All Students \n 3: Exit");
            int.TryParse(Console.ReadLine(), out int ChoiceId);

            switch (ChoiceId)
            {
                case 1:
                    AddStudent(ref ColStudent);
                    break;
                case 2:
                    DisplayAllStudents(ref ColStudent);
                    break;
                case 3:
                    Console.WriteLine("Goodbye.");
                    return;
                default:
                    Console.WriteLine("Invalid Selection...");
                    break;
            }
        }
    }

    public static void AddStudent(ref Collection<Student> aColStudent)
    {
        Console.WriteLine("Enter Student ID: ");
        int.TryParse(Console.ReadLine(), out int StudentId);

        if (aColStudent.Any(x => x.StudentId == StudentId))
        {
            Console.WriteLine("Duplicate ID...");
            return;
        }

        Console.WriteLine("Enter Student Name: ");
        string? StudentName = Console.ReadLine();

        Student ObjStudent = new Student();
        ObjStudent.InsertStudent(StudentId, StudentName);
        aColStudent.Add(ObjStudent);
    }

    public static void DisplayAllStudents(ref Collection<Student> aColStudent)
    {
        if (aColStudent.Any())
        {
            foreach (var ObjStudent in aColStudent)
            {
                Console.WriteLine($"Student ID : {ObjStudent.StudentId} and Student Name : {ObjStudent.StudentName}");
            }
        }
        else
        {
            Console.WriteLine("No Record Exists...");
        }
    }
}