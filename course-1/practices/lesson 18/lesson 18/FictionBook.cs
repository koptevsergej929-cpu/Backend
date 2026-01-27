using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_18
{
    public class FictionBook : Book
    {
        public string Ganre { get; set; }

        public FictionBook(string title, string author, int year, int pages, string ganre)
            : base(title, author, year, pages)
        {
            Ganre = ganre;
        }
    }
}
