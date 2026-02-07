using System;
using System.Collections.Generic;
using System.Text;

namespace nowember_8
{
    public class Manager : Worker
    {
        public override void Work()
        {
            Console.WriteLine($"{Name} - Планирует задачи");
        }
    }
}
