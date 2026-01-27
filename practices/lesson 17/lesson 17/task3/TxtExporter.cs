using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_17.task3
{
    public class TxtExporter : IDocumentExporter
    {
        public string FormatName => "TXT";
        public void Export(string content)
        {
            Console.WriteLine("Сохраняем текстовый файл...");
        }
    }
}
