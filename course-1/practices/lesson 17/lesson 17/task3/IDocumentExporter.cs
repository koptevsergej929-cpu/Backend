using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_17.task3
{
    internal interface IDocumentExporter
    {
        string FormatName { get; }
        void Export(string content);

        void ShowInfo(string content)
        {
            Console.WriteLine($"Экспорт в формат {FormatName}: {content}");
        }
    }
}
