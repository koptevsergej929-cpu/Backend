using System.Xml.Schema;

namespace Lesson_14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Animal dog = new Dog();
            Animal cat = new Cat();
            Animal cow = new Cow();

            dog.Speak();
            cat.Speak();
            cow.Speak();


            Console.WriteLine("____________________");

            Transport[] vehicles =
            {
                new Car { Model = "Audi"},
                new Boat { Model = "Yamaha"},
                new Plane { Model = "Boeing"}
            };

            foreach (var v in vehicles)
            {
                v.Move();
            }

            Console.WriteLine("_____________________");


            Shap[] shapes =
            {
                new Circle { Radius = 5},
                new Square { Side = 4},
                new Rectangle { Width = 3, Height = 6}
            };

            foreach (var s in vehicles)
            {
                Console.WriteLine(s.GetArea());
            }
        }

    }


    public abstract class Shap
    {
        public abstract double GetArea();
    }


    public class Circle : Shap
    {
        public double Radius { get; set; }
        public override double GetArea()
        {
            return Math.Round(Math.PI * Radius * Radius, 1);
        }
    }


    public class Square : Shap
    {
        public double Side { get; set; }
        public override double GetArea()
        {
            return Side * Side;
        }
    }


    public class Rectangle : Shap
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public override double GetArea()
        {
            return Width * Height;
        }
    }
    
    public class Transport
    {
        public string Model { get; set; }

        public virtual void Move()
        {
            Console.WriteLine($"{Model}: транспорт движется");
        }
    }

    public class Car : Transport
    {
        public override void Move()
        {
            base.Move();
            Console.WriteLine("Машина едет по дороге");
        }
    }

    public class Boat : Transport
    {
        public override void Move()
        {
            base.Move();
            Console.WriteLine("Лодка плывёт по воде");
        }
    }


    public class Plane : Transport
    {
        public override void Move()
        {
            base.Move();
            Console.WriteLine("Самолёт летит в небе");
        }
    }

    public class Animal
    {
        public virtual void Speak()
        {
            Console.WriteLine("Животное издаёт звук");
        }
    }

    public class Dog : Animal
    {
        public override void Speak()
        {
            Console.WriteLine("Собака говорит:Гав - гав!");
        }
    }

    public class Cat : Animal
    {
        public override void Speak()
        {
            Console.WriteLine("Кошка говорит: Мяу!");
        }
    }

    public class Cow : Animal
    {
        public override void Speak()
        {
            Console.WriteLine("Корова говорит: Муу!");
        }
    }

}
