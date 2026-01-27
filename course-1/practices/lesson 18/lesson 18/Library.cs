using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_18
{
    public class Library : ILibraryManagement
    {
        private List<Book> _book = new List<Book>();

        public void AddBook(Book book)
        {
            _book.Add(book);
            Console.WriteLine($"Книга \"{book.Title}\" добавлена в библеотеку.");
        }

        public bool RemoveBook(Book book)
        {
            bool removed = _book.Remove(book);
            if (removed == true)
                Console.WriteLine($"Книга \"{book.Title}\" добавлена в библеотеку.");
        }

        public List<Book> SearchByAuthor(string author)
        {
            var book = _book.Where(book => book.Author == author).ToList();
            return book;
        }

        public void ListBooks()
        {
            Console.WriteLine("Список книг в библеотеке");
            foreach (var book in _book)
            {
                book.ShowInfo();
            }
        }

        public void IssueBook(Book book, Reader reader)
        {
            if (_book.Contains(book))
            {
                reader.BorrowBook(book);
                _book.Remove(book);
            }
        }
    }
}
