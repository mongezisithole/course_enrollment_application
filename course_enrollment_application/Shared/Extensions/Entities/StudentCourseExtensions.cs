using course_enrollment_application.Data.Entities;
using course_enrollment_application.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course_enrollment_application.Shared.Extensions.Entities
{
    public static class StudentCourseExtensions
    {
        public static void Deregister(this StudentCourse studentCourse)
        {
            if (studentCourse == null) throw new ArgumentNullException("Student course not found");

            studentCourse.IsActive = false;
            studentCourse.DeregistrationDate = DateTime.Now;
            studentCourse.LastModifiedDate = DateTime.Now;
        }

        public static void Register(this StudentCourse studentCourse, Student student, Course course, AcademicYear currentAcademicYear)
        {
            if (studentCourse == null) throw new ArgumentNullException("Student course not found");

            studentCourse.StudentId = student.Id;
            studentCourse.CourseId = course.Id;
            studentCourse.AcademicYearId = currentAcademicYear.Id;
            studentCourse.RegistrationDate = DateTime.Now;
            studentCourse.AcademicYearId = currentAcademicYear.Id;
        }

        public static void ReactivateCourse(this StudentCourse studentCourse, AcademicYear currentAcademicYear)
        {
            if (studentCourse == null) throw new ArgumentNullException("Student course not found");

            studentCourse.IsActive = true;
            studentCourse.DeregistrationDate = null;
            studentCourse.AcademicYearId = currentAcademicYear.Id;
            studentCourse.LastModifiedDate = DateTime.Now;
        }
        public static StudentCourseSummary ConvertToSummary(this StudentCourse studentCourse)
        {
            if (studentCourse == null) throw new ArgumentNullException("Student course not found");

            return new StudentCourseSummary
            {
                Id = studentCourse.Id,
                StudentNumber = studentCourse.Student?.StudentNumber,
                CourseName = studentCourse.Course?.Name,
                RegistrationDate = studentCourse.RegistrationDate,
                AcademicYear = studentCourse.AcademicYear?.Name
            };
        }

        public static List<StudentCourseSummary> ConvertToSummaries(this List<StudentCourse> studentCourses)
        {
            if (studentCourses == null) throw new ArgumentNullException("Student course not found");

            return studentCourses.Select(o => o.ConvertToSummary()).ToList();
        }
    }
}
