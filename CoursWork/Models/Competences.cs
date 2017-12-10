using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursWork.Models
{
    public class Competences
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Norm { get; set; }

        public Position Position { get; set; }
    }
}
