using course_enrollment_application.Data.Entities.Base;
using System.Security.Claims;

namespace course_enrollment_application.Data.Entities
{
    public class User: EntityBase
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public ClaimsPrincipal ToClaimsPrincipal() => new(new ClaimsIdentity(new Claim[]
        {
        new (ClaimTypes.Name, Username),
        new (ClaimTypes.Hash, Password),
        new (nameof(Email), Email)
        },
        "Course Registration"));

        public static User FromClaimsPrincipal(ClaimsPrincipal principal) => new()
        {
            Username = principal.FindFirst(ClaimTypes.Name)?.Value ?? "",
            Password = principal.FindFirst(ClaimTypes.Hash)?.Value ?? "",
            Email = principal.FindFirst(nameof(Email))?.Value ?? "",
        };

    }
}
