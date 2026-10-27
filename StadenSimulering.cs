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
            
            
            List<Program.Personer> personer =  staden.City(); //Hämtar listan med objekt från klassen staden

           
            
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
            }

            while (true )
            {
                
                Thread.Sleep(1000);
                Console.Clear();
                
                for (int y = 0; y < 25; y++) // Skriver ut objektens symboler på positionerna angivna i egenskaperna 
                {
                    
                    for (int x = 0; x < 100; x++)
                    {
                        Console.Write(Karta[y, x]); //Utskrift 

                        
                    }
                    Console.WriteLine();
                    
                }
               
            }


           



        }
        
        
    }
    
}
