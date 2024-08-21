using course_enrollment_application.Data.Context;
using course_enrollment_application.Repositories;
using course_enrollment_application.Shared.DTOs;
using course_enrollment_application.Shared.Extensions.Entities;
using Microsoft.EntityFrameworkCore;

namespace course_enrollment_application.Repository.Implementations
{
    public class CourseRepo : ICourseRepo
    {
        public readonly DataContext _context;

        public CourseRepo(DataContext context) 
        {
            _context = context;
        }

        public Task<bool> AddCourse(CreateCourseDetails courseDetails)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeactivateCourse(int courseId)
        {
            try
            {
                var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == courseId);

                if (course == null) return false;

                course.Deactivate();
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //Log error
                throw;
            }
        }

        public async Task<CourseDetails> GetCourseDetails(int courseId)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == courseId);

            if (course == null) return null;

            return course.ConvertToDetails();
        }

        public async Task<List<CourseSummary>> GetCourses()
        {
            var courses = await _context.Courses.ToListAsync();

            return courses.ConvertToSummaries();
        }
    }
}
