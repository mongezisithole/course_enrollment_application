using course_enrollment_application.Repositories;
using course_enrollment_application.Repository.Implementations;
using course_enrollment_application.Shared.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace course_enrollment_application.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseRepo courseRepo;

        public CoursesController(ICourseRepo courseRepo)
        {
            this.courseRepo = courseRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<CourseSummary>> GetAsync()
        {
            return await courseRepo.GetCourses();
        }
    }
}
