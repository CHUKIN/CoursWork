using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursWork.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Dicription { get; set; }
        public string PhotoUrl { get; set; }
        public DateTime Date { get; set; }
        public List<UserCourse> UserCourses { get; set; }
        public List<Module> Modules { get; set; }
    }
}
