using course_enrollment_application.Data.Context;
using course_enrollment_application.Data.Entities;

namespace course_enrollment_application.Data.Seeding
{
    public static class Seed
    {
        public static void SeedData(DataContext context)
        {
            if (!context.Courses.Any())
            {
                var courses = new List<Course>();

                for (int i = 1; i <= 10; i++)
                {
                    courses.Add(
                        new Course
                        {
                            DateCreated = DateTime.Now,
                            Description = $"Course {i} description",
                            Id = i,
                            IsActive = true,
                            Name = $"Course {i}",
                        });
                }

                context.Courses.AddRange(courses);
                context.SaveChanges();
            }

            if (!context.Students.Any())
            {
                var students = new List<Student>();

                for (int i = 1; i <= 10; i++)
                {
                    var studentNumber = 20241780 + i;

                    students.Add(
                        new Student
                        {
                            DateCreated = DateTime.Now,
                            FirstName = $"Student{i}_name",
                            Id = i,
                            IsActive = true,
                            DateOfBirth = DateTime.Now,
                            Email = $"student{i}@uni.ac.za",
                            LastName = $"Student{i}_surname",
                            StudentNumber = studentNumber.ToString(),
                        });
                }

                context.Students.AddRange(students);
                context.SaveChanges();
            }

            if (!context.AcademicYears.Any())
            {
                context.AcademicYears.Add(
                    new AcademicYear
                    {
                        DateCreated = DateTime.Now,
                        Description = "2024 Academic year",
                        EndDate = new DateTime(2024, 12, 31),
                        Id = 1,
                        IsActive = true,
                        IsCurrentYear = true,
                        Name = "2024",
                        StartDate = new DateTime(2024, 1, 1)
                    });
                context.SaveChanges();
            }

            if (!context.StudentCourses.Any())
            {
                var studentCourses = new List<StudentCourse>();

                for (int i = 1; i <= 2; i++)
                {
                    
                    studentCourses.Add(
                        new StudentCourse
                        {
                            DateCreated = DateTime.Now,
                            Id = i,
                            IsActive = true,
                            AcademicYearId = 1,
                            CourseId = i,
                            StudentId = 1,
                            RegistrationDate = DateTime.Now,
                        });
                }

                context.StudentCourses.AddRange(studentCourses);
                context.SaveChanges();
            }

            if (!context.Users.Any())
            {
                var users = new List<User>();

                for (int i = 1; i <= 2; i++)
                {
                    var studentNumber = 20241780 + i;

                    users.Add(
                        new User
                        {
                            DateCreated = DateTime.Now,
                            Id = i,
                            IsActive = true,
                            Email = $"student{i}@uni.ac.za",
                            Password = "Password" ,
                            Username = studentNumber.ToString()
                        });
                }

                context.Users.AddRange(users);
                context.SaveChanges();
            }

        }
    }
}
