using course_enrollment_application.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course_enrollment_application.Repositories
{
    public interface IStudentCourseRepo
    {
        Task<bool> StudentCourseRegistration(string studentNumber, int courseId);

        Task<bool> StudentCourseDeregistration(int studentId, int courseId);

        Task<List<StudentCourseSummary>> GetStudentCourses(string studentNumber);

        Task<List<CourseSummary>> GetAvailableCourses(string studentNumber);
    }
}
