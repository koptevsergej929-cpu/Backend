namespace nomber_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var car = new Car { Model = "Audi" };
            car.Accelerate(100);
            car.ShowInfo();
            car.Move();

            var bike = new Bicycly { Model = "Cube" };
            bike.Pedal();
            bike.ShowInfo();
            bike.Move();

            Console.WriteLine("_______________________");

            Charater[] team =
            {
                new Warrior { Name = "Алекс"},
                new Mage { Name = "Лия"},
                new Archer { Name = "Робин"}
            };

            foreach (var c in team)
            {
                Console.Write($"{c.Name}: ");
                c.Attack();
            }
        }
        public class Transport
        {
            protected int Speed = 0;
            public string Model { get; set; }

            public void ShowInfo()
            {
                Console.WriteLine($"Модель: {Model}, скорость: {Speed} км/ч");
            }

            public virtual void Move()
            {
                Console.WriteLine("Транспорт движится.");
            }



        }

        public class Car : Transport
        {
            public void Accelerate(int value)
            {
                if ((Speed + value) > 200)
                    Console.WriteLine("Слишком большая скорасть!");
                else Speed += value;
            }

            public override void Move()
            {
                Console.WriteLine("Машина едет по дороге.");
            }
        }


        public class Bicycly : Transport
        {
            public void Pedal()
            {
                Speed += 5;
            }

            public override void Move()
            {
                Console.WriteLine("Велосипет крутит педали.");
            }
        }


        public abstract class Charater
        {
            public string Name { get; set; }

            public abstract void Attack();
        }

        public class Warrior : Charater
        {
            public override void Attack()
            {
                Console.WriteLine("Воин атакует мечом!");
            }
        }

        public class Mage : Charater
        {
            public override void Attack()
            {
                Console.WriteLine("Маг выпускает огненный шар!");
            }
        }

        public class Archer : Charater
        {
            public override void Attack()
            {
                Console.WriteLine("Лучник стреляет из лука!");
            }
        }
    }
}
