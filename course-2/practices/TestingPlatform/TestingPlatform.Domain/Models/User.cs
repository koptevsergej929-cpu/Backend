namespace TestingPlatform.Models
{
    public class User
    {
        public enum UserRole
        {
            Manager = 1,
            Student = 2,
        }
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public UserRole Role { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public Student? Student { get; set; }
    }
}

