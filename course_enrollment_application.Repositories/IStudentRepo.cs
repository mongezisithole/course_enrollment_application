using course_enrollment_application.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course_enrollment_application.Repositories
{
    public interface IStudentRepo
    {
        Task<bool> CreateStudent(CreateStudentDetails studentDetails);
    }
}
