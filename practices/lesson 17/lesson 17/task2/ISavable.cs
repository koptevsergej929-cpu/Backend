using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_17.task2
{
    internal interface ISavable
    {
        void Write(string filename, string contant);
    }
}
