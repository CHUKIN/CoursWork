using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursWork.Models
{
    public class Theory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public int StepNumber { get; set; }
        public List<UserTheory> UserTheorys { get; set; }
        public int ModuleId { get; set; }
        public Module Module { get; set; }
    }
}
