using System.ComponentModel.Design;

namespace ур_9
{
    internal class Program
    {
        static void Main(string[] args)
        {

        
        void SayHello()
        {
                Console.WriteLine("Привет мир!");
        }
            SayHello();
            SayHello();
            SayHello();


            void Greet(string name)
            {
                Console.WriteLine("Привет, " + name);
            }
            Greet("Саша");
            Greet("Анна");
            Greet("Ярослав");


            void PrintPerson(string name, int age, string city)
            {
                Console.WriteLine("Имя: " + name + "Возраст: " + age + "Город: " + city);
            }

            PrintPerson("Максим", 15, "Москва");
            PrintPerson("Саня", 15, "Москва");


            void PrintPersen2(string name, int age = 18, string hobby = "Не указано")
            {
                Console.WriteLine("Имя: " + name + "Возраст: " + age + "Хобби: " + hobby);
            }
            PrintPersen2("Катя", 20);

            int Square(int x)
            {
                return x * x;
            }

            Square(5);

            //////////////

            Console.Write("Введите первое число");
            int a = int.Parse(Console.ReadLine());

            Console.Write("Введите второе число");
            int b = int.Parse(Console.ReadLine());

            Console.Write("Введите операцию (+, -, *, /): ");
            string operation = Console.ReadLine();

           
            if (operation == "+")
            {
               Console.WriteLine(Add(a, b));
            }
            else if (operation == "-")
            {
                Console.WriteLine(Subtract(a, b));
            }
            else if (operation == "*")
            {
                Console.WriteLine(Multiply(a, b));
            }
            else if (operation == "/")
            {
                if (b == 0)
                {
                    Console.WriteLine("На ноль делить нельзя");
                }
                else
                {
                    Console.WriteLine(Multiply(a, b));
                }
            }
            else
            {
                Console.WriteLine("Не коррекный оператор");
            }

            int Add(int a, int b)
            {
                return a + b;
            }

            int Subtract(int a, int b)
            {
                return a - b;
            }

            int Multiply(int a, int b)
            {
                return a * b;
            }

            int Divide(int a, int b)
            {
                return a / b;
            }

            /////////////////////
            


        }
    }
}
