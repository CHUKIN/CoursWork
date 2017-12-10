using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursWork.Models
{
    public class UserTestResults
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int TestResultsId { get; set; }
        public TestResults TestResults { get; set; }

        //public int TestId { get; set; }
        //public Test Test { get; set; }

        public int NumberOfTest { get; set; }

        public bool Finished { get; set; }
    }
}
