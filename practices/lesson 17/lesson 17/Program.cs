using lesson_17.task1;
using lesson_17.task2;
using lesson_17.task3;

namespace lesson_17
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPlayable[] instruments =
            {
                new Guitar(),
                new Piano(),
                new Drum()
            };

            foreach (var instr in instruments)
            {
                instr.Play();
            }

            Console.WriteLine("____________________");

            var doc = new TextDocument();
            doc.Write("data.txt", "givgy");
            doc.Save();
            Console.WriteLine("Контант: " + doc.Read("рмрви.txt"));

            Console.WriteLine("_____________________");

            IDocumentExporter[] exporters =
            {
                new TxtExporter(),
                new PdfExporter()
            };

            foreach (var exporter in exporters)
            {
                exporter.ShowInfo("Hello world");
                exporter.Export("Hello world");
            }
        }
    }
}
