using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_18
{
    public class Reader
    {
        public string Name { get; set; }

        public int Id { get; set; }
        private List<Book> _borrowedBook = new List<Book>();

        public Reader(string name, int id)
        {
            Name = name;
            Id = id;
        }

        public void BorrowBook(Book book)
        {
            _brrowedBook.Add(book);
            Console.WriteLine($"{Name} взял книгу \"{book.Title}\"");
        }

        public void ShowBorrowedBooks()
        {
            Console.WriteLine($"Книги у {Name}:");
            foreach (var book in _borrowedBook)
            {
                book.ShowInfo();
            }
        }
    }
}
