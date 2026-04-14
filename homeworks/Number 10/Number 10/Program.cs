namespace Number_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int> { 12, 5, 8, 19, 3 };
            Console.WriteLine("Исходный список: " + string.Join(" ", numbers));

            numbers.Sort();
            Console.WriteLine("Отсортированный: " + string.Join(" ", numbers));

            int min = numbers[0];
            int max = numbers[1];
            Console.WriteLine($"Минимум: {min}, Максимум: {max}");

            numbers.Reverse();
            Console.WriteLine("После Reverse: " + string.Join(" ", numbers));

            Console.WriteLine("-----------------------------------------------");

            var phoneBook = new Dictionary<string, string>();
            phoneBook.Add("Анна", "8921-123-45-67");
            phoneBook.Add("Иван", "8931-555-77-88");
            phoneBook.Add("Ольга", "8905-111-22-33");

            string name = "Иван";
            if (phoneBook.ContainsKey(name))
                Console.WriteLine($"Телефон {name}: {phoneBook[name]}");

            name = "Петр";
            if (phoneBook.TryGetValue(name, out var phone))
                Console.WriteLine($"Телефон {name}: {phone}");
            else
                Console.WriteLine($"Контакт {name} не найден");

            Console.WriteLine("-----------------------------------------------");

            var clients = new Queue<string>();
            clients.Enqueue("Анна");
            clients.Enqueue("Иван");
            clients.Enqueue("Мария");
            clients.Enqueue("Олег");

            Console.WriteLine($"Первый {clients.Peek()}");

            while (clients.Count > 0)
            {
                string c = clients.Dequeue();
                Console.WriteLine($"Обслужен клиент: {c}");
            }
            Console.WriteLine("Очередь пуста");

            Console.WriteLine("-----------------------------------------------");

            var actions = new Stack<string>();
            actions.Push("Открыт документ");
            actions.Push("Написан текст");
            actions.Push("Удалён абзац");

            Console.WriteLine($"Верхнее действие: {actions.Peek()}");

            while (actions.Count > 0)
            {
                string act = actions.Pop();
                Console.WriteLine($"Отмена действия: {act}");
                Console.WriteLine($"Осталось действий: {actions.Count}");
            }

            Console.WriteLine("-----------------------------------------------");

            var prices = new Dictionary<string, int>
            {
                    { "Кофе", 150 },
                    { "Чай", 100 },
                    { "Сэндвич", 250 }
            };

            var customers = new Queue<string>();
            customers.Enqueue("Анна");
            customers.Enqueue("Иван");

            var orderItems = new List<string> { "Кофе", "Сэндвич" };

            Console.WriteLine("Обслуживание клиентов:");
            while (customers.Count > 0)
            {
                var client = customers.Dequeue();
                Console.WriteLine($"\nКлиент {client}:");

                int total = 0;
                foreach (var item in orderItems)
                {
                    int price = prices[item];
                    total += price;
                    Console.WriteLine($"  {item} -- {price} руб.");
                }
                Console.WriteLine($"Итого: {total} руб.");
            }

            Console.WriteLine("-----------------------20------------------------>>>");

            string path = "notes.txt";

            File.WriteAllLines(path, new[]
            {
                "Заметка 1",
                "Заметка 2",
                "Заметка 3"
            });

            File.AppendAllText(path, Environment.NewLine + "Заметка 4");

            Console.WriteLine("Содержимое файла:");
            Console.WriteLine(File.ReadAllText(path));

            Console.Write("Удалить файл? (y/n): ");
            if (Console.ReadLine()?.Trim().ToLowerInvariant() == "y")
            {
                File.Delete(path);
                Console.WriteLine("Файл удалён.");
            }

            string dir = "data";
            Directory.CreateDirectory(dir);

            File.WriteAllText(Path.Combine(dir, "a.txt"), "A");
            File.WriteAllText(Path.Combine(dir, "b.txt"), "BBBB");
            File.WriteAllText(Path.Combine(dir, "b.md"), "CCC");

            foreach (var f in Directory.GetFiles(dir, "*.txt"))
            {
                var info = new FileInfo(f);
                Console.WriteLine($"{info.Name} -- {info.Length} байт");
            }

            Console.Write("Путь к файлу: ");
            string? src = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(src) && File.Exists(src))
            {
                string dir = Path.GetDirectoryName(src)!;
                string name = Path.GetFileName(src);
                string bak = Path.Combine(dir, name + ".bak");
                File.Copy(src, bak, overwrite: true);
                Console.WriteLine($"Создана копия: {bak}");
            }
            else
            {
                Console.WriteLine("Файл не найден.");
            }

            string logsDir = "logs";
            Directory.CreateDirectory(logsDir);

            string file = Path.Combine(logsDir, $"{DateTime.Now:yyyy-MM-dd}.log");
            File.AppendAllText(file, $"{DateTime.Now:O} :: событие\n");

            int days = 7;
            foreach (var f in Directory.GetFiles(logsDir, "*.log"))
            {
                var info = new FileInfo(f);
                if (info.CreationTimeUtc < DateTime.UtcNow.AddDays(-days))
                {
                    info.Delete();
                }
            }

            Console.WriteLine("-----------------------уровень_2------------------------>>>");

            List<Book> books = new List<Book>();

            void SaveBooks(List<Book> books)
            {
                using (var writer = new StreamWriter("books.txt"))
                {
                    foreach (var book in books)
                    {
                        writer.WriteLine($"{book.Title};{book.Author}");
                    }
                }
            }

            List<Book> LoadBooks()
            {
                var books = new List<Book>();

                if (File.Exists("books.txt"))
                {
                    foreach (var line in File.ReadAllLines("books.txt"))
                    {
                        var parts = line.Split(';');
                        if (parts.Length == 2)
                        {
                            books.Add(new Book { Title = parts[0], Author = parts[1] });
                        }
                    }
                }

                return books;
            }
        }
    }
}
