using course_enrollment_application.Data.Context;
using course_enrollment_application.Repositories;
using course_enrollment_application.Shared.DTOs;
using course_enrollment_application.Shared.Extensions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course_enrollment_application.Repository.Implementations
{
    public class StudentRepo : IStudentRepo
    {
        public readonly DataContext _context;

        public StudentRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateStudent(CreateStudentDetails studentDetails)
        {
            try
            {
                var student = _context.Students.FirstOrDefault(o => o.Email == studentDetails.Email);

                if (student != null) return false;

                student.AddNewStudentDetails(studentDetails);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                //Log exception
                throw;
            }
        }
    }
}
