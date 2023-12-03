using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cumulative2.Models
{
    public class Teacher
    {
        //The following fields define an Author
        public int TeacherId;
        public string TeacherFname;
        public string TeacherLname;
        public string EmployeeNumber;
        public DateTime Hiredate;
        public decimal Salary;

        //parameter-less constructor function
        public Teacher() { }
    }
}