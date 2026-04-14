namespace lesson_19
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
            int max = numbers[^1];
            Console.WriteLine($"Минимум: {min}, Максимум: {max}");

            numbers.Reverse();
            Console.WriteLine("После Reverse: " + string.Join(" ", numbers));

            Console.WriteLine("------------------------------------");

            var phoneBook = new Dictionary<string, string>();

            phoneBook.Add("Анна", "8921-123-45-67");
            phoneBook.Add("Иван", "8931-555-77-88");
            phoneBook.Add("Ольга", "742856946596");

            string name = "Иван";
            if (phoneBook.ContainsKey(name))
            {
                Console.WriteLine($"Телефон {name}: {phoneBook[name]}");
            }

            Console.WriteLine("------------------------------------");

            name = "Пётр";
            if (phoneBook.TryGetValue(name, out var phone))
            {
                Console.WriteLine($"Телефон {name}: {phoneBook[name]}");
            }
            else
            {
                Console.WriteLine($"Контакт {name} не найден");
            }

            Console.WriteLine("------------------------------------");

            var clients = new Queue<string>();

            clients.Enqueue("Анна");
            clients.Enqueue("Иван");
            clients.Enqueue("Мария");
            clients.Enqueue("Олег");

            Console.WriteLine($"Первый в очереди: {clients.Peek()}");

            while (clients.Count > 0)
            {
                string c = clients.Dequeue();
                Console.WriteLine($"Обслужен клиент: {c}");
            }

            var actions = new Stack<string>();

            actions.Push("Открыт документ");
            actions.Push("Написан текст");
            actions.Push("Удалён абзац");

            Console.WriteLine($"Верниее действие: {actions.Peek()}");

            while (actions.Count > 0)
            {
                string act = actions.Pop();
                Console.WriteLine($"Отмена действия: {act}");
                Console.WriteLine($"Осталось действий: {actions.Count}");
            }
        }
    }
}
