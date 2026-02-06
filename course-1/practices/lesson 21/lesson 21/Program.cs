using System.Text.Json;

namespace lesson_21
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string _PATH_ = "C:\\Users\\admin\\Desktop\\pazzle-portfolio\\course-1\\practices\\lesson 21\\lesson 21\\Book.cs";

            var library = new Library()
            {
                Name = "City library",
                Books = new List<Book>
                {
                new Book{Title = "book 1", Author = "Author 1", Year = 1869},
                new Book{Title = "book 2", Author = "Author 2", Year = 1866}
                }
            };

            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(library, options);

            File.WriteAllText(_PATH_, json);

            var jsonFromFile = File.ReadAllText(_PATH_);
            var libraryFromFile = JsonSerializer.Deserialize<List<Book>>(jsonFromFile);

            if (libraryFromFile != null)
            {
                Console.WriteLine($"Библеотека: {libraryFromFile.Name}");
                foreach (var book in libraryFromFile.Books)
                {
                    Console.WriteLine($"Название: {book.Title}, Автор: {book.Author}, Год: {book.Year}");
                }
            }


        }
    }
}
