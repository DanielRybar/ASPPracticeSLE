using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentsWithIdentity.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace StudentsWithIdentity.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
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
            

            // identity seed
            // uzivatel
            var hasher = new PasswordHasher<ApplicationUser>();
            mb.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = "caa3e5b9-5e96-4ce9-aa16-2a0b0520e815",
                Email = "danryba@pslib.cz",
                NormalizedEmail = "DANRYBA@PSLIB.CZ",
                EmailConfirmed = true,
                UserName = "danryba@pslib.cz",
                NormalizedUserName = "DANRYBA@PSLIB.CZ",
                Firstname = "Daniel",
                Lastname = "Rybář",
                LockoutEnabled = false,
                SecurityStamp = string.Empty,
                PasswordHash = hasher.HashPassword(null, "beruska")

            });

            // role
            mb.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "5c9c1e5f-401c-4cc2-a395-eb1f3c927998",
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            });

            // prirazeni role uzivateli
            mb.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "5c9c1e5f-401c-4cc2-a395-eb1f3c927998",
                UserId = "caa3e5b9-5e96-4ce9-aa16-2a0b0520e815"
            });

            // claim a jeho prirazeni uzivateli
            mb.Entity<IdentityUserClaim<string>>().HasData(new IdentityUserClaim<string>
            {
                Id = 1,
                UserId = "caa3e5b9-5e96-4ce9-aa16-2a0b0520e815",
                ClaimType = "admin",
                ClaimValue = "1"
            });
        }
    }
}
