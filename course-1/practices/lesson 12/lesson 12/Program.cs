namespace lesson_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dog = new Dog("Шарик");
            dog.Eat();
            dog.Bark();
            dog.Speak();
            dog.Move();

            Console.WriteLine("__________________");

            var cat = new cat("Мурка");
            cat.Eat();
            cat.Meow();
            cat.Speak();

            Console.WriteLine("__________________");

            var transport = new Transport();
            var car = new Car();
            var tesla = new ElectriceCar();

            transport.Drive();
            car.Drive();
            tesla.Drive();

        }
        public class Animal
        {
            public string Name { get; set; }

            public Animal(string name)
            {
                Name = name;
                Console.WriteLine("Создано животное: " + name);
            }

            public void Eat()
            {
                Console.WriteLine("Животное ест.");
            }

            public virtual void Speak()
            {
                Console.WriteLine("Животное издаёт звук.");
            }

            public virtual void Move()
            {
                Console.WriteLine("Животное двигается.");
            }
        }

        public class Dog : Animal
        {
            public void Bark()
            {
                Console.WriteLine("Собака лает");
            }

            public Dog(string name) : base(name)
            {
            }

            public override void Speak()
            {
                Console.WriteLine("Собака говорит: Гав-гав!");
            }

            public override void Move()
            {
                base.Move();
                Console.WriteLine("Собака бежит по дороге");
            }
        }

        public class cat : Animal
        {
            public void Meow()
            {
                Console.WriteLine("Кошка мяукает");
            }

            public cat(string name) : base(name)
            {
                Console.WriteLine("Создана кошка по имени: " + Name);
            }

            public override void Speak()
            {
                Console.WriteLine("Кошка говорит: Мяу-мяу!");
            }
        }

        public class Transport
        {
            public virtual void Drive()
            {
                Console.WriteLine("Транспорт движится");
            }
        }

        public class Car : Transport
        {
            public override void Drive()
            {
                Console.WriteLine("Машина едет по дороге");
            }
        }

        public class ElectriceCar : Car
        {
            public override void Drive()
            {
                Console.WriteLine("электромобиль тихо едет нп батарее");
            }
        }

    }
}
