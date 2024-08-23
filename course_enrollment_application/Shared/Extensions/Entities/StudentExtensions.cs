using course_enrollment_application.Data.Entities;
using course_enrollment_application.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course_enrollment_application.Shared.Extensions.Entities
{
    public static class StudentExtensions
    {
        public static void AddNewStudentDetails(this Student student, CreateStudentDetails studentDetails)
        {
            if (student == null) throw new ArgumentNullException("Student course not found");

            student.Email = studentDetails.Email;
            student.DateCreated = DateTime.Now;
            student.DateOfBirth = studentDetails.DateOfBirth;
            student.Email = studentDetails.Email;
            student.FirstName = studentDetails.FirstName;
            student.LastName = studentDetails.LastName;
            student.StudentNumber = GenerateStudentNumber(studentDetails.DateOfBirth);
        }

        private static string GenerateStudentNumber(DateTime dob)
        {
            return $"{DateTime.Now.ToString("yy")}{dob.ToString("yyMMdd")}";
        }
    }
}
