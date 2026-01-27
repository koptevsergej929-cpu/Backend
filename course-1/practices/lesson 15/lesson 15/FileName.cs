using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_15
{
    internal class FileName
    {
    }

    public class Animal
    {
        public string Name { get; set; }

        private int _energy = 100;

        public Animal(string name)
        {
            Name = name;
        }

        public Animal() : this("Неизвестный") { }

        public void Eat()
        {
            ChangeEnergy(10);
            Console.WriteLine($"{Name} ест. Энергия: { _energy}");
            
        }

        public void MakeSound()
        {
            ChangeEnergy(-5);
            Console.WriteLine($"{Name} издаёт звук. Энергия: { _energy}");
        }

        public void Rest()
        {
            ChangeEnergy(+5);
            Console.WriteLine($"{Name} отдыхает. Энергия: {_energy}");
        }

        public void ChangeEnergy(int delta)
        {
            _energy += delta;
            if (_energy < 0) _energy = 0;
            if (_energy > 150) _energy = 150;
        }
    }
}
