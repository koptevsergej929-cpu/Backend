using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using TestingPlatform.Models;

namespace TestingPlatform.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students => Set<Student>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Project> Projects => Set<Project>();
        public DbSet<Models.Group> Groups => Set<Models.Group>();
        public DbSet<Direction> Directions => Set<Direction>();
        public DbSet<Course> Courses => Set<Course>();
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(e =>
            {
                e.HasKey(x => x.Id);
                e.HasIndex(x => x.Login).IsUnique();
                e.HasIndex(x => x.Email).IsUnique();
                e.Property(x => x.Login).IsRequired();
                e.Property(x => x.Email).IsRequired();
                e.Property(x => x.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
                e.HasOne(x => x.Student)
                    .WithOne(s => s.User)
                    .HasForeignKey<Student>(s => s.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Student>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Phone).HasMaxLength(30).IsRequired(); ;
                e.Property(x => x.VkProfileLink).IsRequired();
            });

            modelBuilder.Entity<Direction>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Name).IsRequired();
                e.HasIndex(x => x.Name).IsUnique();
            });

            modelBuilder.Entity<Course>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Name).IsRequired();
                e.HasIndex(x => x.Name).IsUnique();
            });

            modelBuilder.Entity<Project>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Name).IsRequired();
                e.HasIndex(x => x.Name).IsUnique();
            });

            modelBuilder.Entity<Models.Group>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Name).IsRequired();
                e.HasIndex(x => x.Name).IsUnique();

                e.HasOne(x => x.Direction)
                    .WithMany(d => d.Groups)
                    .HasForeignKey(x => x.DirectionId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.Course)
                    .WithMany(c => c.Groups)
                    .HasForeignKey(x => x.CourseId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.Project)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(x => x.ProjectId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Test>(e =>
            {
                e.HasKey(x => x.Id);

                e.Property(x => x.Title).IsRequired();
                e.Property(x => x.Description).IsRequired();
                e.Property(x => x.PublishedAt).IsRequired();
                e.Property(x => x.Deadline).IsRequired();

                // enum как строка
                e.Property(x => x.Type).HasConversion<string>();

                // дефолты
                e.Property(x => x.IsRepeatable).HasDefaultValue(false);
                e.Property(x => x.IsPublic).HasDefaultValue(false);
                e.Property(x => x.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

                // 1:many Test → Questions (каскад)
                e.HasMany(x => x.Questions)
                    .WithOne(q => q.Test)
                    .HasForeignKey(q => q.TestId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Question>(e =>
            {
                e.HasKey(x => x.Id);

                e.Property(x => x.Text).IsRequired();
                e.Property(x => x.Number).IsRequired();
                e.Property(x => x.Description).HasMaxLength(2000);

                e.Property(x => x.AnswerType).HasConversion<string>();
                e.Property(x => x.IsScoring).HasDefaultValue(true);

                // уникальный составной индекс (TestId, Number)
                e.HasIndex(x => new { x.TestId, x.Number }).IsUnique();

                // 1:many Question → Answers (каскад)
                e.HasMany(x => x.Answers)
                    .WithOne(a => a.Question)
                    .HasForeignKey(a => a.QuestionId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Answer>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Text).IsRequired();
                e.Property(x => x.IsCorrect).IsRequired();
            });

            modelBuilder.Entity<Attempt>(e =>
            {
                e.HasKey(x => x.Id);

                e.Property(x => x.StartedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
                e.Property(x => x.SubmittedAt).IsRequired(false);
                e.Property(x => x.Score).IsRequired(false);

                // many:1 Attempt → Test (Restrict — нельзя удалить тест с попытками)
                e.HasOne(x => x.Test)
                    .WithMany()
                    .HasForeignKey(x => x.TestId)
                    .OnDelete(DeleteBehavior.Restrict);

                // 1:many Attempt → UserAttemptAnswers (каскад)
                e.HasMany(x => x.UserAttemptAnswers)
                    .WithOne(ua => ua.Attempt)
                    .HasForeignKey(ua => ua.AttemptId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<UserAttemptAnswer>(e =>
            {
                e.HasKey(x => x.Id);

                e.Property(x => x.IsCorrect).IsRequired();
                e.Property(x => x.ScoreAwarded).IsRequired();

                // уникальный составной индекс (AttemptId, QuestionId)
                e.HasIndex(x => new { x.AttemptId, x.QuestionId }).IsUnique();

                // many:1 → Question (Restrict)
                e.HasOne(x => x.Question)
                    .WithMany(q => q.UserAttemptAnswers)
                    .HasForeignKey(x => x.QuestionId)
                    .OnDelete(DeleteBehavior.Restrict);

                // 1:many → UserSelectedOptions (каскад)
                e.HasMany(x => x.UserSelectedOptions)
                    .WithOne(so => so.UserAttemptAnswer)
                    .HasForeignKey(so => so.UserAttemptAnswerId)
                    .OnDelete(DeleteBehavior.Cascade);

                // 1:1 → UserTextAnswer (FK на UserTextAnswer.UserAttemptAnswerId, каскад)
                e.HasOne(x => x.UserTextAnswer)
                    .WithOne(ta => ta.UserAttemptAnswer)
                    .HasForeignKey<UserTextAnswer>(ta => ta.UserAttemptAnswerId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<UserSelectedOption>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.UserAttemptAnswerId).IsRequired();
                e.Property(x => x.AnswerId).IsRequired();

                // many:1 → Answer (Restrict)
                e.HasOne(x => x.Answer)
                    .WithMany(a => a.UserSelectedOptions)
                    .HasForeignKey(x => x.AnswerId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<UserTextAnswer>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.TextAnswer).IsRequired();
                e.Property(x => x.UserAttemptAnswerId).IsRequired();

                e.HasIndex(x => x.UserAttemptAnswerId).IsUnique();
            });

            modelBuilder.Entity<TestResult>(e =>
            {
                e.HasKey(x => x.Id);

                e.Property(x => x.Passed).IsRequired();

                // уникальный составной индекс (TestId, StudentId, AttemptId)
                e.HasIndex(x => new { x.TestId, x.StudentId, x.AttemptId }).IsUnique();

                // many:1 → Test (Restrict)
                e.HasOne(x => x.Test)
                    .WithMany()
                    .HasForeignKey(x => x.TestId)
                    .OnDelete(DeleteBehavior.Restrict);

                // many:1 → Attempt (каскад)
                e.HasOne(x => x.Attempt)
                    .WithMany()
                    .HasForeignKey(x => x.AttemptId)
                    .OnDelete(DeleteBehavior.Cascade);

                // many:1 → Student — настройка уже в Student
            });


        }
    }
}
