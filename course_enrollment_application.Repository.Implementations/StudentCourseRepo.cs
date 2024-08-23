using course_enrollment_application.Data.Context;
using course_enrollment_application.Data.Entities;
using course_enrollment_application.Repositories;
using course_enrollment_application.Shared.DTOs;
using course_enrollment_application.Shared.Extensions.Entities;
using Microsoft.EntityFrameworkCore;

namespace course_enrollment_application.Repository.Implementations
{
    public class StudentCourseRepo : IStudentCourseRepo
    {
        public readonly DataContext _context;

        public StudentCourseRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<List<StudentCourseSummary>> GetStudentCourses(string studentNumber)
        {
            try
            {
                var student = _context.Students.FirstOrDefault(o => o.StudentNumber == studentNumber);

                if (student == null) throw new ArgumentNullException("Student details not found");

                var currentAcademicYear = _context.AcademicYears.FirstOrDefault(o => o.IsCurrentYear);

                if (currentAcademicYear == null) return new List<StudentCourseSummary>();

                var studentCourses = await _context.StudentCourses
                    .Include(o => o.Course)
                    .Include(o => o.Student)
                    .Include(o => o.AcademicYear).Where(o => o.StudentId == student.Id
                    && o.AcademicYearId == currentAcademicYear.Id && o.IsActive).ToListAsync();

                return studentCourses.ConvertToSummaries();
            }
            catch (Exception ex)
            {
                //Log exception
                throw;
            }
        }

        public async Task<bool> StudentCourseDeregistration(int studentId, int courseId)
        {
            try
            {
                var studentCourse = _context.StudentCourses.FirstOrDefault(o => o.StudentId == studentId && o.CourseId == courseId && o.IsActive);

                if (studentCourse == null)
                    return false;

                var currentAcademicYear = _context.AcademicYears.FirstOrDefault(o => o.IsCurrentYear);

                if (currentAcademicYear?.Id != studentCourse.AcademicYearId)
                    return false;

                studentCourse.Deregister();
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                //Log exception
                throw;
            }
        }

        public async Task<bool> StudentCourseRegistration(string studentNumber, int courseId)
        {
            try
            {
                var currentAcademicYear = _context.AcademicYears.FirstOrDefault(o => o.IsCurrentYear);
                var student = _context.Students.FirstOrDefault(o => o.StudentNumber == studentNumber && o.IsActive);
                var course = _context.Courses.FirstOrDefault(o => o.Id == courseId && o.IsActive);

                if (currentAcademicYear == null || student == null || course == null)
                {
                    return false;
                }

                var studentCourse = _context.StudentCourses.FirstOrDefault(o => o.CourseId == courseId && o.StudentId == student.Id);

                if(studentCourse != null)
                {
                    studentCourse.ReactivateCourse(currentAcademicYear);
                }
                else
                {
                    studentCourse.Register(student, course, currentAcademicYear);

                    await _context.StudentCourses.AddAsync(studentCourse);
                }

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                //Log exception
                throw;
            }
        }

        public async Task<List<CourseSummary>> GetAvailableCourses(string studentNumber)
        {
            try
            {
                var student = _context.Students.FirstOrDefault(o => o.StudentNumber == studentNumber && o.IsActive);

                if (student == null) throw new ArgumentNullException("Student details not found");

                var currentAcademicYear = _context.AcademicYears.FirstOrDefault(o => o.IsCurrentYear);
                var availableCourse = await _context.Courses.Where(o => o.IsActive).ToListAsync();

                if (currentAcademicYear == null)
                {
                    return availableCourse.ConvertToSummaries();
                }

                var studentCourses = await _context.StudentCourses.Where(o => o.StudentId == student.Id
                    && o.AcademicYearId == currentAcademicYear.Id && o.IsActive).Select(o => o.CourseId).ToListAsync();

                return availableCourse.Where(o => !studentCourses.Contains(o.Id)).ToList().ConvertToSummaries();
            }
            catch (Exception ex)
            {
                //Log exception
                throw;
            }
        }
    }
}
