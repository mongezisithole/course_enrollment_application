using course_enrollment_application.Repositories;
using course_enrollment_application.Shared.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace course_enrollment_application.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCourseController : ControllerBase
    {
        private  readonly IStudentCourseRepo _studentCourseRepo;

        public StudentCourseController(IStudentCourseRepo studentCourseRepo)
        {
            _studentCourseRepo = studentCourseRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<StudentCourseSummary>> GetAsync([FromQuery] string studentNumber)
        {
            return await _studentCourseRepo.GetStudentCourses(studentNumber);
        }

        [HttpGet("available")]
        public async Task<IEnumerable<CourseSummary>> GetAvailableAsync([FromQuery] string studentNumber)
        {
            return await _studentCourseRepo.GetAvailableCourses(studentNumber);
        }

        [HttpPost("deregister")]
        public async Task<bool> DeregisterAsync([FromBody] StudentCourseDeregistrationDetails deregistrationDetails)
        {
            return await _studentCourseRepo.StudentCourseDeregistration(deregistrationDetails.StudentId, deregistrationDetails.CourseId);
        }
    }
}
