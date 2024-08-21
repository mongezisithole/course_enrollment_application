using course_enrollment_application.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course_enrollment_application.Data.Context
{
    public class DataContext : DbContext
    {
        //protected readonly IConfiguration Configuration;

        //public DataContext(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        public DataContext(DbContextOptions<DataContext> options)
        : base(options: options) { }
        
        public DbSet<User> Users { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<AcademicYear> AcademicYears { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            
            options.UseInMemoryDatabase("course_enrollment_application_db");
        }

    }

    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        /// <summary>
        /// A factory for creating DataContext instance
        /// </summary>
        /// <param name="args">command-line arguments for EF commands</param>
        /// <returns></returns>
        public DataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseInMemoryDatabase("course_enrollment_application_db");
            
            return new DataContext(optionsBuilder.Options);
        }
    }
}
