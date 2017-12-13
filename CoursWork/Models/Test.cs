using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursWork.Models
{

    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StepNumber { get; set; }
        public string Question { get; set; }
        public int ModuleId { get; set; }
        public Module Module { get; set; }
        public List<TestResults> TestResulties { get; set; }
        public List<UserTestResults> UserTestResulties { get; set; }
    }
}
