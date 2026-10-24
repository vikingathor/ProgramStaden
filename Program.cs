using Microsoft.VisualBasic;

namespace ProgramStaden
{
    internal class Program
    {
            internal class Personer
            {
                public List<string> Names { get; set; }
                public string Name { get; set; } //Lista med 20 namn som är unika för varje medborjare 

                public int Posx { get; set; }
                public int PosY { get; set; }
                public char Type { get; set; }
                public int Where { get; set; }

                public Personer()
                {
                    Name = Names[Random.Shared.Next(0, Names.Count)];  //Hur vet den vilket namn som underklassen ska ha ? 
                    Posx = Random.Shared.Next(0, 100);
                    PosY = Random.Shared.Next(0, 25);
                    Type = 'U';
                    Where = Random.Shared.Next(0, 9);
                }
            }
        public class Medborgare : Personer
        {
            public List<string> Inventory {  get; set; }
            public Medborgare() : base()
            {
                Inventory = new List<string>
                {
                    "Nycklar",
                    "Mobiltelefon",
                    "Pengar",
                    "Klocka",
                };
                Type = 'M';

            }
        }

        public class Polis : Personer
        {
            public List<string> Inventory { get; set; }
            public Polis() : base()
            {
                Inventory = new List<string>
                {

                };
                Type = 'P';
            }
        }

        public class Tjuv : Personer
        {
            public List<string> Inventory { get; set; }
            public Tjuv () : base()
            {
                Inventory = new List<string>
                {

                };
                Type = 'T';
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Tjena världe");
        }
    }
}
