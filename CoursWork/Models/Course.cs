using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public List<UserCourse> UserCourses { get; set; }
        public List<Module> Modules { get; set; }
    }
}
