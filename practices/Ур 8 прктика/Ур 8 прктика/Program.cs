namespace Ур_8_прктика
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 3, 7, 9, 10, 16 };

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"Элемент номер {i}: ");
                Console.WriteLine(numbers[i]);
            }


            int[] grades = { 5, 2, 3, 5, 1, 4 };
            int[] gradesSum = 0;

            for (int i = 0; i < grades.Lenght; i++)
            {
                gradesSum = gradesSum + grades[i];
            }


            double avg = (double)gradesSum / grades.Length;
            Console.Write("Средняя оценнка: ");
            Console.WriteLine(avg);


            int[] nombers2 = { 49, 2, 99, 34, 56, 34, 1, 23};
            int min = 0;
            int max = 0;

            for (int i = 0; i < numbers2.Lenght; i++)
            {
                if (numbers2[i] > max)
                    max = numbers2[i];
            }
            Console.WriteLine(max);
        }
    }
}
