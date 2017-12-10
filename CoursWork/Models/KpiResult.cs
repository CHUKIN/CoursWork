using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursWork.Models
{
    public class KpiResult
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Result { get; set; }
        public User User { get; set; }
        public string Comment { get; set; }
    }
}
