using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course_enrollment_application.Data.Entities.Base
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;


    }
}
