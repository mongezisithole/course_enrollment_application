using course_enrollment_application.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course_enrollment_application.Repositories
{
    public interface ICourseRepo
    {
        Task<bool> AddCourse(CreateCourseDetails courseDetails);

        Task<bool> DeactivateCourse(int courseId);

        Task<List<CourseSummary>> GetCourses();

        Task<CourseDetails> GetCourseDetails(int courseId);
    }
}
