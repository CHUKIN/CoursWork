using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursWork.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patroyomic { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Position Position { get; set; }
        public Role Role { get; set; }
        public List<KpiResult> KpiResults { get; set; }
        public List<UserCourse> UserCourses { get; set; }
        public List<UserTheory> UserTheorys { get; set; }
        public List<UserTestResults> UserTestResulties { get; set; }
    }
}
