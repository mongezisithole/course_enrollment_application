using course_enrollment_application.Data.Context;
using course_enrollment_application.Repositories;
using course_enrollment_application.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course_enrollment_application.Repository.Implementations
{
    public class StudentRepo: IStudentRepo
    {
        public readonly DataContext _context;

        public StudentRepo(DataContext context)
        {
            _context = context;
        }

        public Task<bool> CreateStudent(CreateStudentDetails studentDetails)
        {
            throw new NotImplementedException();
        }
    }
}
