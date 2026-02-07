using System;
using System.Collections.Generic;
using System.Text;

namespace nowember_8
{
     public class Soup : CookingProcess
    {
        protected override void MainProcess()
        {
            Console.WriteLine("Суп: варим овощи и мясо до готовности");
        }
    }
}
