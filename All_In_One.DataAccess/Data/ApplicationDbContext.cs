
using All_In_One.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace All_In_One.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<StudentTeacher> StudentTeacher { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        //protected override void OnModelCreating(ModelBuilder modelbuilder)
        //{
        //    modelbuilder.Entity<Teacher>().HasNoKey().HasData(
        //        new Teacher { TeacherId=9000,TeacherName="Teacher1",SubjectOfTeacher ="Subject1", TeacherMail="Mail1"},
        //        new Teacher { TeacherId=9001 ,TeacherName="Teacher2",SubjectOfTeacher ="Subject2", TeacherMail="Mail2"}

        //        );
        //}
    }
}
