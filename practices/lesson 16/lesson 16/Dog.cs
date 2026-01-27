using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_16
{
    public class Dog : Animal
    {
        public Dog(string name) : base(name) { }
        public override void MakeSoud()
        {
            Console.WriteLine($"{Name}: Гав-гав!");
        }
    }
}
