using course_enrollment_application.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course_enrollment_application.Data.Entities
{
    public class StudentCourse: EntityBase
    {

        public int StudentId { get; set; }

        [ForeignKey(nameof(StudentId))]
        public Student Student { get; set; }

        public int CourseId { get; set; }

        [ForeignKey(nameof(CourseId))]
        public Course Course { get; init; }

        public int AcademicYearId { get; set; }

        [ForeignKey(nameof(AcademicYearId))]
        public AcademicYear AcademicYear { get; set; }

        public DateTime RegistrationDate { get; set; }

        public DateTime? DeregistrationDate { get; set; }

    }
}
