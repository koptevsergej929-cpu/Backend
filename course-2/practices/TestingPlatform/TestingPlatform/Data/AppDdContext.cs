using Microsoft.EntityFrameworkCore;
using TestingPlatform.Models;

namespace TestingPlatform.Data
{
    public class AppDdContext : DbContext
    {
        public DbSet<Student> Students => Set<Student>();
        public AppDdContext(DbContextOptions<AppDdContext> options) : base(options)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student { 
               Id = 1,
               Login = "vanya123", 
               Email = "vanya123@mail.com",
               FirstName = "Иван",
               MiddleName = "Иванович", 
               LastName = "Иванов", 
               Phone = "+71234567890", 
               VkProfileLink = "http://vk.com/vanya123",
               CreatedAt =new DateTime(2026, 9, 23) },
           new Student {
               Id = 2, 
               Login = "maria",
               Email = "maria@mail.com",
               FirstName = "Мария",
               MiddleName = "Ивановна",
               LastName = "Иванова",
               Phone = "+71234567899",
               VkProfileLink = "http://vk.com/vanya123",
               CreatedAt =new DateTime(2026, 9, 23) }
                );
        }
    }
}
