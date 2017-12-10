using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoursWork.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patroyomic { get; set; }
        public string Gender { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public List<KpiResult> KpiResults { get; set; }
        public List<UserCourse> UserCourses { get; set; }
        public List<UserTheory> UserTheorys { get; set; }
        public List<UserTestResults> UserTestResulties { get; set; }
    }
}
