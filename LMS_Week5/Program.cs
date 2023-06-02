using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LMS_Week5.BL;
using System.IO;
using System.Threading.Tasks;

namespace LMS_Week5
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            List<Degree> degrees = new List<Degree>();
            List<Subject> subjects = new List<Subject>();
            ReadStudentData( students);
            ReadDegreesData(degrees);
            ReadSubjectData(subjects);
            int option;           
            do
            {
                Console.Clear();
                Console.WriteLine("1. Add Student ");
                Console.WriteLine("2. Add Degree Program");
                Console.WriteLine("3. Generate Merit");
                Console.WriteLine("4. View Registered Students");
                Console.WriteLine("5. View Students of a specific Program");
                Console.WriteLine("6. Register Subjects for a Specific Students");
                Console.WriteLine("7. Calculate Fees for all Registered Students");
                Console.WriteLine("8. Exit");
                Console.WriteLine("Enter Option: ");
                option = int.Parse(Console.ReadLine());
                if (option == 1)
                {
                    AddStudent(students);
                }
                else if(option == 2)
                {
                    AddDegree(degrees, subjects);
                }
                else if (option == 3)
                {
                    GenerateMeritList(students);
                }
                else if (option == 4)
                {
                    DisplayStudentData(students);
                }
                else if (option == 5)
                {
                    ViewStudentsByDegree(students);
                }
                else if (option == 6)
                {
                    RegisterSubjects(students, subjects);
                }
                else if (option == 7)
                {
                    CalculateFees(students, subjects);
                }
                else if (option == 8)
                {
                    break;
                }
                Console.ReadKey();
            }
            while (option < 9);
        }
        static void AddStudent(List<Student> students)
        {
            Console.WriteLine("Enter Your Full Name");
            string studentName = Console.ReadLine();
            Console.WriteLine("Enter Your Age");
            int age = int.Parse(Console.ReadLine());          
            Console.WriteLine("Enter Your FSC Marks");
            int fscMarks = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Your ECAT Marks");
            int ecatMarks = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Available Degree Program");
            string AvailableDegree = Console.ReadLine();
            Console.WriteLine("Enter Number of preferences");
            int noofpreferences = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Preference");
            string preferences = Console.ReadLine();
            Student student = new Student(studentName, age, fscMarks, ecatMarks,AvailableDegree,preferences);
            students.Add(student);
            using (StreamWriter file = new StreamWriter(@"E:\SecondSemester\LMS_Week5\StudentFile.txt", true))
            {
                file.WriteLine($"{studentName},{age},{fscMarks},{ecatMarks},{AvailableDegree},{preferences}");
            }

        }
        static void ReadStudentData(List<Student> students)
        {
            string studentPath = @"E:\SecondSemester\LMS_Week5\StudentFile.txt";
            if (File.Exists(studentPath))
            {
                using (StreamReader file = new StreamReader(studentPath))
                {
                    string record;
                    while ((record = file.ReadLine()) != null)
                    {
                        string[] fields = record.Split(',');
                        if (fields.Length >= 6  )
                        {
                            string studentName = fields[0];
                            int age = int.Parse(fields[1]);
                            int fscMarks = int.Parse(fields[2]);
                            int ecatMarks = int.Parse(fields[3]);
                            string AvailableDegree = fields[4];                            
                            string preferences = fields[5];                          
                            Student student = new Student(studentName, age,fscMarks, ecatMarks, AvailableDegree, preferences);
                            students.Add(student);
                        }
                        else
                        {
                            Console.WriteLine($"Invalid record: {record}");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine($"File does not exist: {studentPath}");
            }
        }
        static void ReadDegreesData(List<Degree> degrees)
        {
            string studentPath = @"E:\SecondSemester\LMS_Week5\DegreeFile.txt";
            if (File.Exists(studentPath))
            {
                using (StreamReader file = new StreamReader(studentPath))
                {
                    string record;
                    while ((record = file.ReadLine()) != null)
                    {
                        string[] fields = record.Split(',');
                        if (fields.Length >= 3)
                        {
                            string degreeName = fields[0];
                            int degreeDuration = int.Parse(fields[1]);
                            int degreeSeats = int.Parse(fields[2]);                           
                            Degree degree = new Degree(degreeName, degreeDuration, degreeSeats);
                            degrees.Add(degree);
                        }
                        else
                        {
                            Console.WriteLine($"Invalid record: {record}");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine($"File does not exist: {studentPath}");
            }
        }
        static void ReadSubjectData(List<Subject> subjects)
        {
            string studentPath = @"E:\SecondSemester\LMS_Week5\SubjectFile.txt";
            if (File.Exists(studentPath))
            {
                using (StreamReader file = new StreamReader(studentPath))
                {
                    string record;
                    while ((record = file.ReadLine()) != null)
                    {
                        string[] fields = record.Split(',');
                        if (fields.Length >= 4)
                        {
                            int subjectCode = int.Parse(fields[0]);
                            string subjectType = fields[1];
                            int subjectCH = int.Parse(fields[2]);
                            int subjectFees = int.Parse(fields[3]);                           
                            Subject subject = new Subject(subjectCode, subjectType, subjectCH, subjectFees);
                            subjects.Add(subject);
                        }
                        else
                        {
                            Console.WriteLine($"Invalid record: {record}");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine($"File does not exist: {studentPath}");
            }
        }
        static void DisplayStudentData(List<Student> students)
        {
            Console.Clear();
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine("Student " + (i + 1) + " Data");
                Console.WriteLine("Student Name = " + students[i].studentName);
                Console.WriteLine("Student Age = " + students[i].age);
                Console.WriteLine("Student FSC Marks = " + students[i].fscMarks);
                Console.WriteLine("Student Ecat Marks = " + students[i].ecatMarks);      
            }           
        }
        static void AddDegree(List<Degree> degrees, List<Subject> subjects)
        {
            Console.Clear();
            Console.WriteLine("Enter Degree Name");
            string degreeName = Console.ReadLine();
            Console.WriteLine("Enter Degree Duaration");
            int degreeDuration = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Degree Seats");
            int degreeSeats = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter how many subjects to Enter");
            int choice = int.Parse(Console.ReadLine());
            for (int i = 0; i < choice; i++)
            {
                Console.WriteLine("Enter Subject Code");
                int subjectCode = int.Parse(Console.ReadLine());
                Console.WriteLine("enter Subject Type");
                string subjectType = Console.ReadLine();
                Console.WriteLine("Enter Subject Credit Hours");
                int subjectCH = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Subject Fees");
                int subjectFees = int.Parse(Console.ReadLine());
                Subject subject = new Subject(subjectCode, subjectType, subjectCH, subjectFees);
                subjects.Add(subject);
                using (StreamWriter file = new StreamWriter(@"E:\SecondSemester\LMS_Week5\SubjectFile.txt", true))
                {
                    file.WriteLine($"{subjectCode},{subjectType},{subjectCH},{subjectFees}");
                }
            }
            Degree degree = new Degree(degreeName, degreeDuration, degreeSeats);
            degrees.Add(degree);
           
            using (StreamWriter file = new StreamWriter(@"E:\SecondSemester\LMS_Week5\DegreeFile.txt", true))
            {
                file.WriteLine($"{degreeName},{degreeDuration},{degreeSeats}");
            }
           

        }
        static void GenerateMeritList(List<Student> students)
        {
            Console.Clear();
            List<Student> meritList = new List<Student>();          
            float finalPercentage = 0;
            foreach (var student in students)
            {              
                finalPercentage = ((student.fscMarks * 60) / 1100) + ((student.ecatMarks * 40) / 400);
                if (finalPercentage >= 50)
                {
                    meritList.Add(student);
                    Console.WriteLine("Student Merit = " + finalPercentage);
                    Console.WriteLine("Student Name: " + student.studentName);
                }

            }
           
              
        }

        static void ViewStudentsByDegree(List<Student> students)
        {
            Console.WriteLine("Enter the degree program to view students:");
            string degreeProgram = Console.ReadLine();

            List<Student> studentsByDegree = students.Where(s => s.AvailableDegree.Equals(degreeProgram, StringComparison.OrdinalIgnoreCase)).ToList();
            if (studentsByDegree.Count > 0)
            {
                Console.WriteLine($"Students enrolled in {degreeProgram}:");
                for (int i = 0; i < studentsByDegree.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {studentsByDegree[i].studentName}");
                }
            }
            else
            {
                Console.WriteLine($"No students enrolled in {degreeProgram}.");
            }
        }

        static void RegisterSubjects(List<Student> students, List<Subject> subjects)
        {
            Console.WriteLine("Enter the student name to register subjects:");
            string studentName = Console.ReadLine();

            Student student = students.FirstOrDefault(s => s.studentName.Equals(studentName, StringComparison.OrdinalIgnoreCase));
            if (student != null)
            {
                Console.WriteLine($"Student found: {student.studentName}");
                Console.WriteLine("Enter the number of subjects to register:");
                int numOfSubjects = int.Parse(Console.ReadLine());
                List<Subject> registeredSubjects = new List<Subject>();

                for (int i = 0; i < numOfSubjects; i++)
                {
                    Console.WriteLine($"Enter subject code {i + 1}:");
                    int subjectCode = int.Parse(Console.ReadLine());
                    Subject subject = subjects.FirstOrDefault(s => s.subjectCode == subjectCode);
                    if (subject != null)
                    {
                        registeredSubjects.Add(subject);
                        Console.WriteLine($"Subject {subject.subjectCode} - {subject.subjectType} registered.");
                    }
                    else
                    {
                        Console.WriteLine($"Subject with code {subjectCode} not found.");
                    }
                }

                student.RegisteredSubjects = registeredSubjects;
                Console.WriteLine("Subjects registered successfully.");
            }
            else
            {
                Console.WriteLine($"Student with name {studentName} not found.");
            }
        }

        static void CalculateFees(List<Student> students, List<Subject> subjects)
        {
            Console.WriteLine("Calculating fees for all registered students...");
            foreach (var student in students)
            {
                double totalFees = student.RegisteredSubjects.Sum(s => s.subjectFees);
                Console.WriteLine($"Student: {student.studentName}, Total Fees: {totalFees}");
            }
        }




    }
}
