using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course_enrollment_application.Shared.DTOs
{
    public class CourseDetails
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Id { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;
    }
}
