namespace Задание_с_7_урока_номер_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Задание 5: Калькулятор оценнок 
            Console.Write("Введите свою оценку");

            string input = Console.ReadLine();
            int a = int.Parse(input);

            if (a < 3)
            {
                Console.WriteLine("Неудовлетворительно");
            }
            else if (a == 3)
            {
                Console.WriteLine("Удовлетворительно");
            }
            else if (a == 4)
            {
                Console.WriteLine("Хорошо");
            }
            else if (a == 5)
            {
                Console.WriteLine("Отлично");
            }


         }  
    }
}
