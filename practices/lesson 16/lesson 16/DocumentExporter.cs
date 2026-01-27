using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_16
{
    public abstract class DocumentExporter
    {
        public abstract string FormatName { get; }

        public abstract void Export(string content);

        public void ShowInfo(string content)
        {
            Console.WriteLine($"Экспорт в формат {FormatName}: {content}");
    }
}
