using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoursWork.Models;

namespace CoursWork.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Competences> Competences { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Departament> Departaments { get; set; }
        public DbSet<KpiResult> KpiResults { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<UserCourse> UserCourses { get; set; }
        public DbSet<Theory> Theories { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<TestResults> TestResulties { get; set; }
        public DbSet<UserTestResults> UserTestResulties { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<UserCourse>().HasKey(u => new { u.UserId, u.CourseId });
            //  modelBuilder.Entity<UserTheory>().HasKey(u => new { u.UserId, u.TheoryId });
            ////  modelBuilder.Entity<UserTestResults>().HasKey(u => new { u.UserId, u.TestResultsId, u.TestId });
            //  modelBuilder.Entity<UserTestResults>().HasOne(s => s.User)
            //.WithMany(s => s.UserTestResulties)
            //.OnDelete(DeleteBehavior.ClientSetNull);
            //  modelBuilder.Entity<UserTestResults>().HasOne(s => s.Test)
            //.WithMany(s => s.UserTestResulties)
            //.OnDelete(DeleteBehavior.ClientSetNull);
          //  modelBuilder.Entity<UserTestResults>().HasOne(s => s.TestResults)
          //.WithMany(s => s.UserTestResults)
          //.OnDelete(DeleteBehavior.SetNull);
        }

        public DbSet<CoursWork.Models.UserTheory> UserTheory { get; set; }
    }
}
