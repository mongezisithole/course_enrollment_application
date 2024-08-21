using course_enrollment_application.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course_enrollment_application.Shared.DTOs
{
    public class StudentCourseSummary
    {
        public int Id { get; set; }

        public string StudentNumber { get; set; }

        public string CourseName { get; set; }

        public string AcademicYear { get; set; }

        public DateTime RegistrationDate { get; set; }
    }
}
