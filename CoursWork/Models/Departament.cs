using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursWork.Models
{
    public class Departament
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Position> Positions {get;set;}
    }
}
