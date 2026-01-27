using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_17.task1
{
    public class Guitar : IPlayable
    {
        public void Play()
        {
            Console.WriteLine("Гитара играет аккорды");
        }
    }
}
