using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course_enrollment_application.Shared.Security
{
    public class UserLoginDto
    {
        public string StudentNumber { get; set; }

        public string Password { get; set; }
    }
}
