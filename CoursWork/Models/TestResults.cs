using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursWork.Models
{
    public class TestResults
    {
        public int Id { get; set; }
        public string Variant { get; set; }
        public bool Correct { get; set; }
        public Test Test { get; set; }

        public List<UserTestResults> UserTestResulties { get; set; }
    }
}
