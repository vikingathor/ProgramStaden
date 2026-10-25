using Microsoft.VisualBasic;

namespace ProgramStaden
{
    internal class Program
    {
            internal class Personer //En bass klass 
            {
                public List<string> Names = File.ReadAllLines("Names.txt").ToList();
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
                Inventory = new List<string> //En ny egenskap för underklassen som innehåller sakerna i inventoryt 
                {
                    "Nycklar",
                    "Mobiltelefon",
                    "Pengar",
                    "Klocka",
                };
                Type = 'M'; //Ändrar typen endast för denna klass 

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
            Staden staden = new Staden();
            staden.City();
        }
    }
}
