using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_18
{
    public class Book
    {
        private string _title;
        private string _author;
        private int _year;
        private int _pages;

        public string Title
        {
            get => _title;
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _title = value;
            }
        }

        public string Author
        {
            get => _author;
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _author = value;
            }
        }

        public int Year
        {
            get => _year;
            set
            {
                if (value > 0)
                    _year = value;
            }
        }

        public int Pages
        {
            get => _pages;
            set
            {
                if (value > 0)
                    _pages = value;
            }
        }


        public Book(string title, string author, int year, int pages)
        {
            Title = title;
            Author = author;
            Year = year;
            Pages = pages;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Книга: {_title}, Автор: {_author}, Год: {_year}, Страниц: {_pages}");
        }
    }
}
