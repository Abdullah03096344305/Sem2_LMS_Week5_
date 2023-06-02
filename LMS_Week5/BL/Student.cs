using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_Week5.BL
{
    class Student
    {
        public string studentName;
        public int age;
        public int fscMarks;
        public int ecatMarks;
        public string AvailableDegree;
        public string preferences;
        public List<Subject> RegisteredSubjects;
        public Student(string studentName, int age,  int fscMarks, int ecatMarks, string AvailableDegree, string preferences)
        {
            this.studentName = studentName;
            this.age = age;
            this.fscMarks = fscMarks;
            this.ecatMarks = ecatMarks;
            this.AvailableDegree = AvailableDegree;
            this.preferences = preferences;
            RegisteredSubjects = new List<Subject>();
        }
    }
    class Degree
    {
        public string degreeName;
        public int degreeDuration;
        public int degreeSeats;
        public Degree(string degreeName, int degreeDuration, int degreeSeats)
        {
            this.degreeName = degreeName;
            this.degreeDuration = degreeDuration;
            this.degreeSeats = degreeSeats;
        }
    }
    class Subject
    {
        public int subjectCode;
        public string subjectType;
        public int subjectCH;
        public int subjectFees;
        public Subject(int subjectCode, string subjectType, int subjectCH, int subjectFees)
        {
            this.subjectCode = subjectCode;
            this.subjectType = subjectType;
            this.subjectCH = subjectCH;
            this.subjectFees = subjectFees;
        }
    }
}
