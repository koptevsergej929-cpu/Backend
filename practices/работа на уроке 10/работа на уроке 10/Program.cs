namespace работа_на_уроке_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var Car = new Car("Audi", 50);
            Car.Accelerate();
            Car.Accelerate();
            Console.WriteLine($"{Car.Brand} едет со скоростью {Car.Speed} км/ч");

            var book = new Book { Title = "Test", Auther = "Test", Pages = 50 };
            book.Read(60);

            var lid = new Libraly();
            lid.AddBook(book);
            lid.AddBook(new Book { Title = "Test2", Auther = "Test2", Pages = 67 });

            lid.PrintAllBooks();
        }

        public class Car
        {
            public string Brand { get; set; }
            public int Speed { get; private set; } = 0;


            public Car(string brand, int speed )
            {
                Brand = brand;
                Speed = speed;
            }

            public void Accelerate()
            {
                Speed += 10;
            }
        }

        public class Libraly
        {
            public List<Book> Books { get; set; } = new List<Book>();

            public void AddBook(Book book)
            {
                Books.Add(book);
            }


            public void PrintAllBooks()
            {
               foreach(var book in Books)
                {
                    Console.WriteLine(book.Title);
                }
            }
            


        }

        public class Book
        {
            public string Title { get; set; }
            public string Auther { get; set; }
            public int Pages { get; set; }


            public void Read ( int pages)
            {
                if (Pages < pages)
                {
                    Console.WriteLine("jfihi" + Pages + "hdb");
                }
                else
                {
                    Console.WriteLine("hfib" + pages + "fjrehgi" + Pages);
                }
            }
        }
    }

}
