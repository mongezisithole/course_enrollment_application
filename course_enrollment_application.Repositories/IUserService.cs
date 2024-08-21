using course_enrollment_application.Shared.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course_enrollment_application.Repositories
{
    public interface IUserService
    {
        String Login(UserLoginDto userLogin);
    }
}
