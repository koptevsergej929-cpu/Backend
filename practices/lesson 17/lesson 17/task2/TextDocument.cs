using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_17.task2
{
    public class TextDocument : IReadable, IWritable, ISavable
    {
        private string _content;
        public string Read(string filename)
        {
            Console.WriteLine($"Чтение из файла {filename}");

            return _content;
        }

        public void Save()
        {
            Console.WriteLine($"Файл сохранён. Содержимое: {_content}");
        }

        public void Write(string filename, string content)
        {
            Console.WriteLine($"Запись в файл: {filename}: {content}");
            _content = content;
        }
    }
}
