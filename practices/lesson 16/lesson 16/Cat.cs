using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_16
{
    public class Cat : Animal
    {
        public Cat(string name) : base(name) { }
        public override void MakeSoud()
        {
            Console.WriteLine($"{Name}: Мяу-мяу!");
        }
    }
}
