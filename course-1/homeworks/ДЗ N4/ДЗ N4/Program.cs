namespace ДЗ_N4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int grade1 = 5;
            int grade2 = 4;
            int grade3 = 5;
            int grade4 = 3;
            int grade5 = 4;
            int grade6 = 5;
            int grade7 = 5;


            int[] grades = { 5, 2, 5, 3, 2, 5, 5 };
            int gradesSum = 0;

            for (int i = 0; i < grades.Length; i++)
            {
                gradesSum = gradesSum +  grades[i];
            }


            double avg = (double)gradesSum / grades.Length;
            Console.Write("Средняя оценка: ");
            Console.WriteLine(avg);

            int number1 = grades.Count(grade => grade == 5);
            Console.WriteLine($"Количесто оценок 5: {number1}");

            int number2 = grades.Count(grade => grade == 2);
            Console.WriteLine($"Количество оценок 2: {number2}");

            
            int[] numbers = { 1, 2, 3, 4, 5 };
            Console.WriteLine($"В прямом порядке: {string.Join(", ", numbers)}");

            Array.Reverse(numbers);
            Console.WriteLine($"В прямом порядке: {string.Join(", ", numbers)}");


            Console.Write("Чётные цифры: ");
            for (int i = 1; i <= 20; i++)
            {
                if (i % 2 != 0)
                {
                    continue;
                }
                Console.Write(i + " ");
            }
            Console.WriteLine();

            Console.Write("Не чётные цифры: ");
            for (int i = 1; i <= 20; i++)
            {
                if (i % 2 == 0)
                {
                    continue;
                }
                Console.Write(i + " ");
            }
            Console.WriteLine();


            const string password = "1234";
            const int maxAttempts = 3;
            int AttemptsConst = 0;

            bool Access = false;
            Console.WriteLine("Введите пароль. Есть 3 попытки.");

            while (AttemptsConst < maxAttempts && !Access)
            {
                AttemptsConst++;

                Console.Write($"Попытка N-{AttemptsConst}. Введите пароль: ");
                string endpassword = Console.ReadLine();

                if (endpassword == password)
                {
                    Console.WriteLine("Правильный пароль");
                    Access = true;

                    break;
                }
                else
                {
                    Console.WriteLine("Неверно набран пароль");
                }
                if (AttemptsConst == maxAttempts)
                {
                    Console.WriteLine("Попытки закончились. Нет доступа ");
                    break;
                }

                
            }
        }
    }
}
