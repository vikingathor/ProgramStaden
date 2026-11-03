using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using static ProgramStaden.Program;

namespace ProgramStaden
{
    internal class StadenSimulering
    {
       
        char[,] Karta = new char[25, 100]; //En matris med 25 rader och 100 kolumner 
        

        public string Meddelande {  get; set; }
        public void FyllerStaden(List<Program.Personer> personers)
        {

            for (int y = 0; y < 25; y++)
            {

                for (int x = 0; x < 100; x++)
                {
                    Karta[y, x] = ','; //Fyller matrisen med tecknet , så vi får 100 kolumner fyllda 

                }
            }

            foreach (var personer in personers)
            {
                if (personer.PosY >= 0 && personer.PosY < 25 &&
                    personer.Posx >= 0 && personer.Posx < 100)
                {
                    if (Karta[personer.PosY, personer.Posx] == ',')
                    {
                        Karta[personer.PosY, personer.Posx] = personer.Type;
                    }
                }
            }

        }

        public void LäggTillPersoner(List<Program.Personer> personers)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo Knapp = Console.ReadKey(true);

                if (Knapp.Key == ConsoleKey.T)
                {
                    personers.Add(new Tjuv());
                    Meddelande = "En Tjuv har kommit till staden ";
                }
                else if (Knapp.Key == ConsoleKey.P)
                {
                    personers.Add(new Polis());
                    Meddelande = "En ny polis har kommit till staden";
                }
                else if (Knapp.Key == ConsoleKey.M)
                {
                    personers.Add(new Medborgare());
                    Meddelande = "En ny medborgare har flyttat in";
                }
            }
           
        }

        public void FlyttaPersoner(List<Program.Personer> personers)
        {
            foreach (var person in personers)
            {
                switch (person.Where)
                {
                    case 0: //Upp
                        person.PosY--;
                        break;

                    case 1: //Upp höger 
                        person.PosY--;
                        person.Posx++;
                        break;

                    case 2: //Höger
                        person.Posx++;
                        break;

                    case 3: //Ner höger 
                        person.PosY++;
                        person.Posx++;
                        break;

                    case 4: //Ner 
                        person.PosY++;
                        break;

                    case 5: //Ner vänster 
                        person.PosY++;
                        person.Posx--;
                        break;

                    case 6: //Vänster
                        person.Posx--;
                        break;

                    case 7: //Upp vänster 
                        person.PosY--;
                        person.Posx--;
                        break;
                }
                KonstrolleraPositioner(person);
            }
        }

        public void KonstrolleraPositioner(Program.Personer person) 
        {
            if (person.Posx >= 100)
                person.Posx = 0;

            if (person.Posx < 0)
                person.Posx = 99;

            if (person.PosY >= 25)
                person.PosY = 0;

            if (person.PosY < 0)
                person.PosY = 24;
        }
          public void Uppdate (List<Program.Personer> persons)
        {
            FlyttaPersoner(persons);
            FyllerStaden(persons);
        }

        public void Utskrift ()
        {
            for (int y = 0; y < 25; y++)
            {
                for (int x = 0; x < 100; x++)
                {
                    Console.Write(Karta[y, x]);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine(Meddelande);
        }
        }
        
        
    }