using Microsoft.EntityFrameworkCore;
using SimpleStudentsDb.Models;

namespace SimpleStudentsDb.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }

        protected override void OnModelCreating(ModelBuilder mb) // seed
        {
            base.OnModelCreating(mb);

            // classrooms
            mb.Entity<Classroom>().HasData(new Classroom() { Id = 1, Name = "P4" });
            mb.Entity<Classroom>().HasData(new Classroom() { Id = 2, Name = "P3" });

            // students
            mb.Entity<Student>().HasData(new Student()
            {
                Id = 1,
                Firstname = "Cyril",
                Lastname = "Cvrček",
                BirthDate = new DateTime(2004, 01, 14),
                ClassroomId = 1
            });
            mb.Entity<Student>().HasData(new Student()
            {
                Id = 2,
                Firstname = "Jana",
                Lastname = "Jánská",
                BirthDate = new DateTime(2005, 05, 06),
                ClassroomId = 2
            });
            mb.Entity<Student>().HasData(new Student()
            {
                Id = 3,
                Firstname = "Adam",
                Lastname = "Alois",
                BirthDate = new DateTime(2003, 12, 02),
                ClassroomId = 1
            });

        }
    }
}