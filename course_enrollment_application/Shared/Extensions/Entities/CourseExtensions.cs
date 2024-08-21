using course_enrollment_application.Data.Entities;
using course_enrollment_application.Shared.DTOs;

namespace course_enrollment_application.Shared.Extensions.Entities
{
    public static class CourseExtensions
    {
        public static void Update(this Course course, CourseDetails details)
        {
            if (course == null) throw new ArgumentNullException(nameof(course));

            course.Name = details.Name;
            course.Description = details.Description;
            course.LastModifiedDate = DateTime.Now;
        }

        public static void Deactivate(this Course course)
        {
            if (course == null) throw new ArgumentNullException(nameof(course));

            course.IsActive = false;
            course.LastModifiedDate = DateTime.Now;
        }

        public static CourseDetails ConvertToDetails(this Course course)
        {
            if(course == null) throw new ArgumentNullException(nameof(course));

            return new CourseDetails
            {
                DateCreated = course.DateCreated,
                Description = course.Description,
                Id = course.Id,
                IsActive = course.IsActive,
                LastModifiedDate = course.LastModifiedDate,
                Name = course.Name,
            };
        }

        public static CourseSummary ConvertToSummary(this Course course)
        {
            if (course == null) throw new ArgumentNullException(nameof(course));

            return new CourseSummary
            {
                Description = course.Description,
                Id = course.Id,
                Name = course.Name,
            };
        }

        public static List<CourseSummary> ConvertToSummaries(this List<Course> courses)
        {
            if (courses == null) throw new ArgumentNullException(nameof(courses));

            return courses.Select(o => o.ConvertToSummary()).ToList();
        }
    }
}
