using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_16
{
    public abstract class Animal
    {
        public string Name { get; set; }

        public Animal(string name)
        {
            Name = name;
            Console.WriteLine($"Создано животное {Name}");
        }


        public void Eat()
        {
            Console.WriteLine($"{Name} есст.");
        }

        public abstract void MakeSoud();
    }
}
