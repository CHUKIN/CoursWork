using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursWork.Models
{
    public class UserTheory
    {
        public int IdUser { get; set; }
        public User User { get; set; }

        public int IdTheory { get; set; }
        public Theory Theory { get; set; }

        public bool Finished { get; set; }
    }
}
