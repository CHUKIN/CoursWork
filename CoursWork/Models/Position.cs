using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursWork.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Departament Departament {get;set;}
        public List<User> Users { get; set; }
        public List<Competences> Competences { get; set; }
    }
}
