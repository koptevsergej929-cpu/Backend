namespace lessons_22
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = {-3, -1, 2, 0, 1, 6, -4, -5, 0, 6 };

            var Filtered = nums
                .Where(n => n > 0 && n % 2 == 0)
                .Select(n => n * n);


            Console.WriteLine(string.Join(", ", Filtered));

            var count = Filtered.Count();
            var sum = Filtered.Sum();
            var avg = Filtered.Average();

            Console.WriteLine($"Count = {count}, Sum = {sum}, avg = {avg}");

            Console.WriteLine("----------------------");

            var words = new List<string>
            {
                "апельсин","Арбуз","ананас","банан","абрикос","груша","Авокадо","арбуз"
            };

            var result = words
                .Where(w => w.StartsWith("а", StringComparison.OrdinalIgnoreCase))
                .Select(w => w.ToUpperInvariant())
                .OrderBy(w => w.Length)
                .Distinct();

            Console.WriteLine(string.Join(", ", result));

            Console.WriteLine("---------------------------");

            var students = new List<student>
            {
                new("Аня",5), new("Борис",3), new("Вика",4), new("Гена",4), new("Дана",5)
            };

            var good = students
                .Where(s => s.Grade >= 4)
                .OrderBy(s => s.Name)
                .Select(s => s.Name);

            bool anyBad = students.Any(s => s.Grade < 3);
            bool allOk = students.All(s => s.Grade >= 3);

            Console.WriteLine(string.Join(", ", good));
        }
        public class student
        {
            public string Name { get; set; }
            public int Grade { get; set; }

            public student(string name, int grade)
            {
                Name = name;
                Grade = grade;
            }
        }
    }
}
