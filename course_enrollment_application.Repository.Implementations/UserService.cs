using course_enrollment_application.Data.Context;
using course_enrollment_application.Data.Entities;
using course_enrollment_application.Repositories;
using course_enrollment_application.Shared.Security;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace course_enrollment_application.Repository.Implementations
{
    public class UserService:IUserService
    {
        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }

        public string Login(UserLoginDto userLogin)
        {
            var user = _context.Users.FirstOrDefault(o => o.Username == userLogin.StudentNumber && o.Password == userLogin.Password);

            if (user == null) return "";

            return GenerateToken(user);
        }

        private string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(""));

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Username),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Sid, user.Id.ToString())
            };

            var token = new JwtSecurityToken("",
                "",
                claims,
                expires: DateTime.Now.AddMinutes(15));


            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
