using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursWork.Models
{
    public class UserCourse
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public bool Appointment { get; set; }
        public bool Finished { get; set; }
        public decimal ResultPercent { get; set; }

    }
}
