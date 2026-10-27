using Microsoft.VisualBasic;

namespace ProgramStaden
{
    internal class Program
    {
            internal class Personer //En bass klass 
            {
                public List<string> Names = File.ReadAllLines("Names.txt").ToList(); //Läser namnen från en txt fil och och lägger dem i en string list = Names 
                public string Name { get; set; } //Egenskap som tilldelar namn till Medborgare, Polis och Tjuv 
                public int Posx { get; set; } // Egenskape som anger positionen på x = Kolumnerna 
                public int PosY { get; set; } //Egenskap som anger positionen på Y = Raderna 
                public char Type { get; set; } // Egenskap som anger vilken symbol som ska visas i staden 
                public int Where { get; set; } //Egenskap som anger vilken riktining personen går mot 

                public Personer() //Konstruktor för huvudklassen 
                {
                    
                    Name = Names[Random.Shared.Next(0, Names.Count)];  //Hur vet den vilket namn som underklassen ska ha ? 
                    Posx = Random.Shared.Next(0, 100); //Random position  x ledet 
                    PosY = Random.Shared.Next(0, 25); //Random postion y ledet 
                    Type = 'U'; //Vilken typ objektet är kommer överskridas vid utskriften 
                    Where = Random.Shared.Next(0, 9); //Ger dem en Random riktning 
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
            StadenSimulering simulation = new StadenSimulering();
            simulation.Simulera();
        }
    }
}
