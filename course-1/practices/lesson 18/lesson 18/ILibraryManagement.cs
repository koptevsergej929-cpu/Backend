using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_18
{
    public interface ILibraryManagement
    {
        void AddBook(Book book);

        void RemoveBook(Book book);

        List<Book> SearhByAuthor(string author);
    }
}
