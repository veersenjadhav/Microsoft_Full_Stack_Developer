using System;
using System.Collections.ObjectModel;

class Student
{
    public int StudentId { get; set; }

    public string? StudentName { get; set; }

    Collection<Report> ColGradeReport = new Collection<Report>();

    /// <summary>
    /// Setting student data to object for storage
    /// </summary>
    /// <param name="aintStudentId"></param>
    /// <param name="lstrStudentName"></param>
    public void SetStudentData(int aintStudentId, string? lstrStudentName)
    {
        this.StudentId = aintStudentId;
        this.StudentName = lstrStudentName;
    }

    /// <summary>
    /// This method inserts subject and respective grade for current student
    /// </summary>
    /// <param name="astrSubjectName"></param>
    /// <param name="adblGrade"></param>
    public void InsertSubjectWiseGrade(string? astrSubjectName, double adblGrade)
    {
        if (ColGradeReport.Any(x => x.SubjectName == astrSubjectName))
        {
            Report objReport = ColGradeReport.Where(x => x.SubjectName?.ToLower() == astrSubjectName?.ToLower()).First();
            objReport.SetSubjectAndGrade(astrSubjectName, adblGrade);
        }
        else
        {
            Report objReport = new Report();
            objReport.SetSubjectAndGrade(astrSubjectName, adblGrade);
            ColGradeReport.Add(objReport);
        }
    }

    /// <summary>
    /// This method contains formatting of displaying individual student info
    /// </summary>
    public void ShowDetailedStudentData()
    {
        if (this.StudentId > 0 && !string.IsNullOrEmpty(StudentName))
        {
            Console.WriteLine($"Student ID : {this.StudentId}, and Student Name : {this.StudentName}");
        }

        if (ColGradeReport.Any())
        {
            foreach (var objReport in ColGradeReport)
            {
                objReport.ShowStudentGrade();
            }

            double Average = AverageGrades();

            if (Average > 0)
            {
                Console.WriteLine($"Total Average is : {Average}");
            }
        }
    }

    /// <summary>
    /// This method used in case of displaying all students info
    /// </summary>
    public void ShowShortStudentData()
    {
        int TotalSubjects = 0;
        double Average = 0;

        if (ColGradeReport.Any())
        {
            TotalSubjects = ColGradeReport.Count;
            Average = AverageGrades();
        }

        if (this.StudentId > 0 && !string.IsNullOrEmpty(StudentName))
        {
            Console.WriteLine($"{this.StudentId}    | {this.StudentName}    | {TotalSubjects}   | {Average}");
        }
    }

    /// <summary>
    /// This method calculates average of student grades
    /// </summary>
    /// <returns>Average Grade Value</returns>
    private double AverageGrades()
    {
        double Average = 0;

        if (ColGradeReport.Any())
        {
            Average = ColGradeReport.Average(x => x.Grade);
        }

        return Average;
    }
}

class Report
{
    public string? SubjectName { get; set; }

    public double Grade { get; set; }

    /// <summary>
    /// Setting up subject name and grade to current student object
    /// </summary>
    public void SetSubjectAndGrade(string? astrSubjectName, double adblGrade)
    {
        this.SubjectName = astrSubjectName;
        this.Grade = adblGrade;
    }

    /// <summary>
    /// This method contains formatting of displaying individual student subject and grade
    /// </summary>
    public void ShowStudentGrade()
    {
        if (this.Grade >= 0 && !string.IsNullOrEmpty(SubjectName))
        {
            Console.WriteLine($"Subject Name : {this.SubjectName}, and Grade for this subject : {this.Grade}");
        }
    }
}

class StudentGradeManagement
{
    /// <summary>
    /// Main function - starting point of program
    /// </summary>
    /// <param name="args"></param>
    public static void Main(string[] args)
    {
        Collection<Student> ColStudent = new Collection<Student>();

        while (true)
        {
            Console.WriteLine("\n 1: Add Student \n 2: Add / Update Subject wise Grades \n 3: Show Student Info \n 4: Show All Students \n 5: Exit");
            if (int.TryParse(Console.ReadLine(), out int ChoiceId))
            {
                switch (ChoiceId)
                {
                    case 1:
                        AddStudent(ref ColStudent);
                        break;
                    case 2:
                        AddOrUpdateSubjectAndGrade(ref ColStudent);
                        break;
                    case 3:
                        DisplayStudentInfo(ColStudent);
                        break;
                    case 4:
                        DisplayAllStudents(ColStudent);
                        break;
                    case 5:
                        Console.WriteLine("Goodbye.");
                        return;
                    default:
                        Console.WriteLine("Invalid Selection...");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid Selection, Please try again...");
            }
        }
    }

    /// <summary>
    /// This function used to add student info
    /// </summary>
    /// <param name="aColStudent"></param>
    public static void AddStudent(ref Collection<Student> aColStudent)
    {
        Console.WriteLine("Enter Student ID: ");
        if (int.TryParse(Console.ReadLine(), out int StudentId))
        {
            if (aColStudent.Any(x => x.StudentId == StudentId))
            {
                Console.WriteLine("Duplicate ID...");
                return;
            }

            Console.WriteLine("Enter Student Name: ");
            string? StudentName = Console.ReadLine();

            Student ObjStudent = new Student();
            ObjStudent.SetStudentData(StudentId, StudentName);
            aColStudent.Add(ObjStudent);

            Console.WriteLine("Student Added...");
        }
        else
        {
            Console.WriteLine("Invalid ID, Please try again...");
            return;
        }
    }

    /// <summary>
    /// This function adds or updates subject and grade for respective student
    /// </summary>
    /// <param name="aColStudent"></param>
    public static void AddOrUpdateSubjectAndGrade(ref Collection<Student> aColStudent)
    {
        if (aColStudent.Any())
        {
            Console.WriteLine("Enter Student ID: ");
            if (int.TryParse(Console.ReadLine(), out int StudentId))
            {
                if (aColStudent.Any(x => x.StudentId == StudentId))
                {
                    Console.WriteLine("Enter Subject Name: ");
                    string? SubjectName = Console.ReadLine();

                    Console.WriteLine("Enter Grade (in decimal): ");
                    if (double.TryParse(Console.ReadLine(), out double Grade) && Grade >= 0 && Grade <= 100)
                    {
                        Student objStudent = aColStudent.Where(x => x.StudentId == StudentId).First();

                        objStudent.InsertSubjectWiseGrade(SubjectName, Grade);

                        Console.WriteLine("Grade Saved...");
                    }
                    else
                    {
                        Console.WriteLine("Invalid Grade, Please try again...");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine($"No Student Exists with Student ID: {StudentId} ...");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID, Please try again...");
                return;
            }
        }
        else
        {
            Console.WriteLine("First Add atleast 1 Student Record to Proceed...");
        }
    }

    /// <summary>
    /// This function displays individual stundent details
    /// </summary>
    /// <param name="aColStudent"></param>
    public static void DisplayStudentInfo(Collection<Student> aColStudent)
    {
        if (aColStudent.Any())
        {
            Console.WriteLine("Enter Student ID: ");
            if (int.TryParse(Console.ReadLine(), out int StudentId))
            {
                if (aColStudent.Any(x => x.StudentId == StudentId))
                {
                    Student objStudent = aColStudent.Where(x => x.StudentId == StudentId).First();
                    objStudent.ShowDetailedStudentData();
                }
                else
                {
                    Console.WriteLine($"No Student Exists with Student ID: {StudentId} ...");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID, Please try again...");
                return;
            }
        }
        else
        {
            Console.WriteLine("First Add atleast 1 Student Record to Proceed...");
        }
    }

    /// <summary>
    /// This function displays all student details
    /// </summary>
    /// <param name="aColStudent"></param>
    public static void DisplayAllStudents(Collection<Student> aColStudent)
    {
        if (aColStudent.Any())
        {
            Console.WriteLine($"Student ID  | Student Name  | Total Subjects    | Average");
            foreach (var ObjStudent in aColStudent)
            {
                ObjStudent.ShowShortStudentData();
            }
        }
        else
        {
            Console.WriteLine("No Record Exists...");
        }
    }
}