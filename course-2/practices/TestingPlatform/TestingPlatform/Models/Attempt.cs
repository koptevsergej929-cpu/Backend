using System.Data;

namespace TestingPlatform.Models
{
    public class Attempt
    {
        public int id {  get; set; }
        public DataSetDateTime StartedAt { get; set; }
        public DataSetDateTime? SubmittedAt { get; set; }
        public int? Score { get; set; }

        public int TestId { get; set; }
        public Test Test { get; set; } = null!;

        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;

        public List<UserAttemptAnswer> UserAttempAnswers { get; set; } = new();
    }
}
