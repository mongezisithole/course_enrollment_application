using course_enrollment_application.Data.Context;
using course_enrollment_application.Repositories;
using course_enrollment_application.Repository.Implementations;
using course_enrollment_application.Server.Extensions;
using Microsoft.EntityFrameworkCore;

namespace course_enrollment_application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IAcademicYearRepo, AcademicYearRepo>();
            builder.Services.AddScoped<ICourseRepo, CourseRepo>();
            builder.Services.AddScoped<IStudentCourseRepo, StudentCourseRepo>();
            builder.Services.AddScoped<IStudentRepo, StudentRepo>();
            builder.Services.AddScoped<IUserService, UserService>();

            //Config db
            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseInMemoryDatabase(databaseName: "course_enrollment_application_db");
                options.EnableSensitiveDataLogging();
            }, ServiceLifetime.Scoped);

            
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();


            app.MapRazorPages();
            app.MapControllers();
            app.MapFallbackToFile("index.html");

            //Data seeding done here
            app.SeedData();

            app.Run();
        }
    }
}