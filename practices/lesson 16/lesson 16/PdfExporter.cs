using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_16
{
    public class PdfExporter : DocumentExporter
    {
        public override string FormatName => "PDF";

        public override void Export(string content)
        {
            Console.WriteLine("Сохраняет PDF-документ.");
        }
    }
}
