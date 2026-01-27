using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_16
{
    public class TxtExporter : DocumentExporter
    {
        public override string FormatName => "TXT";

        public override void Export(string content)
        {
            Console.WriteLine("Сохраняет текстовый файл.");
        }
    }
}
