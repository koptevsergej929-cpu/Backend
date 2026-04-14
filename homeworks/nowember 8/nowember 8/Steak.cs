using System;
using System.Collections.Generic;
using System.Text;

namespace nowember_8
{
    public class Steak : CookingProcess
    {
        protected override void MainProcess()
        {
            Console.WriteLine("Стейк: жарим мясо до готовности");
        }
    }
}
