namespace nowember_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Worker[] workers = { new Manager { Name = "Анна" }, new Developer { Name = "Иван" } };
            foreach (var w in workers)
            {
                w.ShowInfo();
                w.Work();
            }

            Console.WriteLine("--------------------------");

            CookingProcess[] dishis =
            {
                new Soup(),
                new Steak()
            };

            foreach (var dish in dishis)
            {
                dish.Cook();
                Console.WriteLine();
            }
        }
    }
}
