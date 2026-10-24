using Microsoft.VisualBasic;

namespace ProgramStaden
{
    internal class Program
    {
            internal class Personer
            {
                public List<string> Names { get; set; }
                public string Name { get; set; }

                public int Posx { get; set; }
                public int PosY { get; set; }
                public char Type { get; set; }
                public int Where { get; set; }

                public Personer()
                {
                    Name = Names[Random.Shared.Next(0, Names.Count)];
                    Posx = Random.Shared.Next(0, 100);
                    PosY = Random.Shared.Next(0, 25);
                    Type = 'U';
                    Where = Random.Shared.Next(0, 9);
                }
            }
        static void Main(string[] args)
        {
            Console.WriteLine("Tjena världe");
        }
    }
}
