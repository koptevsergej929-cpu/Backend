using System.Security.Cryptography.X509Certificates;

namespace Homeworke_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var phone = new Phone { Model = "Samsung Galaxy" };

            phone.Charge(30);
            Console.WriteLine($"Заряд: {phone.Battery}%");

            phone.Use(10);
            Console.WriteLine($"Заряд: {phone.Battery}%");
        }
    }
    public class Phone
    {
        public string Model { get; set; }

        public int Battery { get; private set; }

        public void Charge (int amount)
        {
            Battery += amount;
            if (Battery > 100)
            {
                Battery = 100;
            }
        }

        public void Use(int amount)
        {
            Battery -= amount;
            if (Battery < 0)
            {
                Battery = 0;
            }
        }
    }
}
