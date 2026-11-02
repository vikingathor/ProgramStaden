using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramStaden
{
    public class StadenSimulering
    {
       
        char[,] Karta = new char[25, 100]; //En matris med 25 rader och 100 kolumner 
        Staden staden = new Staden(); //Objekt av staden ger oss åtkomst


        public void Simulera()
        {

            List<Program.Personer> personer = staden.City(); //Hämtar listan med objekt från klassen staden




            for (int y  = 0; y < 25; y++) 
            {
                
                for (int x = 0;  x < 100; x++)
                {
                    Karta[y, x] = ','; //Fyller matrisen med tecknet , så vi får 100 kolumner fyllda 
                    
                }
            }

            foreach (var person in personer) //Fyller matrisen med person objekten 
            {
                if (Karta[person.PosY, person.Posx] == ',')
                {
                    Karta[person.PosY, person.Posx] = person.Type; // Överskrider tecknet med symbolen för just det objektet 
                    
                } // Om Positionen där objektet ska skrivas ut är täckt med en , symbol överskrids den 
                
            }


            string Meddelande = "";
            while (true )
            {
                Thread.Sleep(1000);
                Console.Clear();

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo tangenten = Console.ReadKey(true);

                    if (tangenten.Key == ConsoleKey.P)
                    {
                        personer.Add(new Program.Polis());
                        Meddelande = "En polis har kommit till staden ";
                    }

                    else if (tangenten.Key == ConsoleKey.T)
                    {
                        personer.Add(new Program.Tjuv());
                        Meddelande = "En tjuv har kommit till staden ";
                    }

                    else if (tangenten.Key == ConsoleKey.M)

                    {
                        personer.Add(new Program.Medborgare());
                        Meddelande = "En ny medborgare har flyttat in i staden";
                    }
                }
                
                foreach (var person in personer)
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
                    if (person.Posx >= 100)
                        person.Posx = 0;
                    if (person.Posx < 0)
                        person.Posx = 99;
                    if (person.PosY >= 25)
                        person.PosY = 0;
                    if (person.PosY < 0)
                        person.PosY = 24;
                }
                for (int y = 0; y < 25;  y++)
                {
                    for (int x = 0; x < 100; x++)
                    {
                        Karta[y, x] = ',';
                    }
                }

                foreach (var person in personer)
                {
                    if (person.PosY >= 0 && person.PosY < 25 &&
                        person.Posx >= 0 && person.Posx < 100)
                    { Karta[person.PosY, person.Posx] = person.Type; }
                }
                
                for (int y = 0; y < 25; y++) // Skriver ut objektens symboler på positionerna angivna i egenskaperna 
                {
                    
                    for (int x = 0; x < 100; x++)
                    {
                        Console.Write(Karta[y, x]); //Utskrift 
                        
                        
                    }
                    
                    Console.WriteLine();

                }
                Console.WriteLine();
                Console.WriteLine(Meddelande);


            }


           



        }
        
        
    }
    
}
