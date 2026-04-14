using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Text;

namespace nowember_8
{
    public abstract class CookingProcess
    {
        public void Cook()
        {
            PrepareIngredients();
            MainProcess();
            Server();
        }

        protected virtual void PrepareIngredients()
        {
            Console.WriteLine("Потготовка ингредиентов");
        }

        protected abstract void MainProcess();

        protected virtual void Server()
        {
            Console.WriteLine("Подача блюда");
        }
    }
}
