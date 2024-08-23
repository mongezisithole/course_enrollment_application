using course_enrollment_application.Repositories;
using course_enrollment_application.Shared.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace course_enrollment_application.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepo _studentRepo;

        public StudentsController(IStudentRepo studentRepo)
        {
            _studentRepo = studentRepo;
        }

        [HttpPost("register")]
        public async Task<bool> RegisterAsync([FromBody] CreateStudentDetails details)
        {
            return await _studentRepo.CreateStudent(details);
        }
    }
}
