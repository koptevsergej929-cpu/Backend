using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace lesson_15
{
    public class Elephant : Animal
    {
        public Elephant() : base("Слон") { }

        public Elephant(string name) : base(name) { }


        public void Trumpet()
        {
            Console.WriteLine($"{Name} пытается лаять...");
            MakeSound();
        }

        public override void MakeSound()
        {
            Console.WriteLine($"{Name}: Туу!);
        }
    }
}
