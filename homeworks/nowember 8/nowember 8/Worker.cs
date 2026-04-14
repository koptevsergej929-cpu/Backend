using System;
using System.Collections.Generic;
using System.Text;

namespace nowember_8
{
    public abstract class Worker
    {
        public string Name { get; set; }

        public abstract void Work();

        public void ShowInfo()
        {
            Console.WriteLine($"Работник: {Name}");
        }
    }
}
