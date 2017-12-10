using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursWork.Models
{
    public class Module
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public List<Theory> Theories { get; set; }
        public List<Test> Tests { get; set; }
    }
}
