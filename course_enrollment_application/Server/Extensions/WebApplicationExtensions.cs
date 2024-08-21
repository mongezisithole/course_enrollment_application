using course_enrollment_application.Data.Context;
using course_enrollment_application.Data.Seeding;

namespace course_enrollment_application.Server.Extensions
{
    public static class WebApplicationExtensions
    {
        public static void SeedData(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<DataContext>()!;

                Seed.SeedData(context);// Seed the database
            }
        }
    }
}
