using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_16
{
    public class Car : Transport
    {
        protected override void MoveCore()
        {
            Console.WriteLine("Машина едет по дороге");
        }
    }
}
