using course_enrollment_application.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course_enrollment_application.Data.Entities
{
    public class Course: EntityBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

    }
}
