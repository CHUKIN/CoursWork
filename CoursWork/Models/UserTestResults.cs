using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursWork.Models
{
    public class UserTestResults
    {
        public int IdUser { get; set; }
        public User User { get; set; }

        public int IdTestResults { get; set; }
        public TestResults TestResults { get; set; }

        public bool Finished { get; set; }
    }
}
