using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_16
{
    public class Boat : Transport
    {
        protected override void MoveCore()
        {
            Console.WriteLine("Лодка плывёт по воде");
        }
    }
}
