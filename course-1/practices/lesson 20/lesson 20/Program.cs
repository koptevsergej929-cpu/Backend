namespace lesson_20
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //    string path = "notes.txt";

            //    File.WriteAllLines(path, new[]
            //    {
            //        "Заметка 1",
            //        "Заметка 2",
            //        "Заметка 3"
            //    });

            //    File.AppendAllText(path, Environment.NewLine + "Заметка 4");

            //    Console.WriteLine("Содержимое файла");
            //    Console.WriteLine(File.ReadAllText(path));

            //    Console.Write("Удалить файл? (y/n): ");
            //    if (Console.ReadLine()?.Trim().ToLowerInvariant() == "y")
            //    {
            //        File.Delete(path);
            //        Console.WriteLine("Файл удалён.");
            //    }
            //}


            string dir = "data";

            Directory.CreateDirectory(dir);

            File.WriteAllText(Path.Combine(dir, "a.txt"), "A");
            File.WriteAllText(Path.Combine(dir, "b.txt"), "BBBB");
            File.WriteAllText(Path.Combine(dir, "b.md"), "CCC");

            foreach (var f in Directory.GetFiles(dir, "*.txt"))
            {
                var info = new FileInfo(f);
                Console.WriteLine($"{info.Name} -- {info.Length}");
            }
        }
    }
}
