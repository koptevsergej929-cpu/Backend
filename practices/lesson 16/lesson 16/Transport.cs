using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_16
{
    public abstract class Transport
    {
        public void Move()
        {
            Start();
            MoveCore();
            Stop();
        }

        protected abstract void MoveCore();

        protected void Stop()
        {
            Console.WriteLine("Stop");
        }

        protected void Start()
        {
            Console.WriteLine("Start");
        }
    }
}
