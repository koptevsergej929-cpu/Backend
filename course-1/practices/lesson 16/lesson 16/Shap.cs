using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_16
{
    public abstract class Shap
    {
        public abstract string Name { get; }

        public abstract double Getarea();

        public void Print()
        {
            Console.WriteLine($"{Name}: площадь ={Getarea()}");
        }
    }
}
