using System.Drawing;

namespace lesson_16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shap[] shapes =
            {
                new Circle {Radius = 5 },
                new Rectangle {Height = 4, Width = 6 }
            }; 

            foreach (var shap in shapes)
            {
                shap.Print();
            }

            Console.WriteLine("-----------");

            Animal[] animals =
            {
                new Cat("Мфрка"),
                new Dog("Рокс")
            };

            foreach (var animal in animals)
            {
                animal.Eat();
                animal.MakeSoud();
            }

            Console.WriteLine("--------------");

            Transport[] transports =
            {
                new Car(),
                new Boat()
            };

            foreach (var transport in transports)
            {
                transport.Move();
            }

            Console.WriteLine("---------------");

            DocumentExporter[] exporters =
            {
                new TxtExporter(),
                new PdfExporter()
            };

            for (int 1 = 0; 1 < exporters.Length; i++)
            {
                exporters[1].ShowInfo("Hello world!");
                exporters[1].Export("Hello world!");
            }
        }
    }
}
