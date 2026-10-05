using Microsoft.EntityFrameworkCore;
using TestingPlatform.Models;

namespace TestingPlatform.Data
{
    public static class DbSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Direction>().HasData(
                new Direction { Id = 1, Name = "Backend-разработка"},
                new Direction { Id = 2, Name = "Frontent-разработка" },
                new Direction { Id = 3, Name = "Data Science" }
            );

            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Name = "1 курс"},
                new Course { Id = 2, Name = "2 курс" },
                new Course { Id = 3, Name = "3 курс" }
            );

            modelBuilder.Entity<Project>().HasData(
                new Project { Id = 1, Name = "Учебный проект"},
                new Project { Id = 2, Name = "Хакатон"}
            );
        }
    }
}
