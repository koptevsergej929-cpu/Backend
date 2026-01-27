using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_17.task3
{
    public class PdfExporter : IDocumentExporter
    {
        public string FormatName => "PDF";
        public void Export(string content)
        {
            Console.WriteLine("Создаём PDF-документ...");
        }
    }
}
