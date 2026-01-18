using System.ComponentModel.Design;

namespace Урок_7_практика
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int nub1 = 10;

            //if (num1 > 0)
            //{
            //    Console.WriteLine("Положительное число");
            //}
            //else if (nub1 < 0) ;
            //{
            //    Console.WriteLine("Число отрицательное");
            //}



            //int age = int.Parse(Console.ReadLine());
            //if (age >= 0) ;
            //{
            //    Console.WriteLine("Вы не совершено летний");
            //}
            //else
            //{
            //    Console.WriteLine("Вы совершенно летний");
            //}

            int num1 = 0;

                if (num1 > 0) ;
            {
                Console.WriteLine("Число положительное");
            }
            else if (num1 < 0) ;
            {
                Console.WriteLine("Число положительное");
            }
            else
            {
                Console.WriteLine("Число равно нулю");
            }

            int age = int.Parse(Console.ReadLine());
            if (age >= 18)
            {
                Console.WriteLine("Вы совершеннолетний");
            }
            else
            {
                Console.WriteLine("ВЫ не совершеннолетний");
            }

            int num = 7;
            if (num % 2 == 0)
            {
                Console.WriteLine("Чило чётное");
            }
            else
            {
                Console.WriteLine("Число не чётное");
            }

            int a = 5;
            int b = 9;

            if (a > 0 && b > 0)
            {
                Console.WriteLine("Оба числа положительные");
            }
            if (a > 0 || b > 0)
            {
                Console.WriteLine("Хотя быодно число положительное");
            }
            if (a < 0 )
            {
                Console.WriteLine("А не положительное");
            }
        }
    }
}
