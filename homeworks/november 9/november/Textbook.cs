using System;
using System.Collections.Generic;
using System.Text;

namespace november
{
    public class Textbook : Book
    {
        public string Subject { get; set; }

        public Textbook(string title, string author, int year, int pages, string subject)
            : base(title, author, year, pages)
        {
            Subject = subject;
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Учебник: {Title}, Предмет: {Subject}, Автор: {Author}, Год: {Year}, Страниц: {Pages}");
        }
    }

    public class FictionBook : Book
    {
        public string Genre { get; set; }

        public FictionBook(string title, string author, int year, int pages, string genre)
            : base(title, author, year, pages)
        {
            Genre = genre;
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Художественная книга: {Title}, Жанр: {Genre}, Автор: {Author}, Год: {Year}, Страниц: {Pages}");
        }

    }
}
