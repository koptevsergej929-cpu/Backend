using System;
using System.Collections.Generic;
using System.Text;

namespace nowember_8
{
    public class Developer : Worker
    {
        public override void Work()
        {
            Console.WriteLine($"{Name} - Пишет код");
        }
    }
}
