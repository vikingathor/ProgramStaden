using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramStaden
{
    public class StadenSimulering
    {
        public void Simulera()
        {
            Staden staden = new Staden(); //Objekt av staden ger oss åtkomst 
            
            List<Program.Personer> personer =  staden.City(); //Hämtar listan med objekt från klassen staden

            char[,] Karta = new char[25, 100]; //En matris med 25 rader och 100 kolumner 

            
            
            for (int y  = 0; y < 25; y++) 
            {
                
                for (int x = 0;  x < 100; x++)
                {
                    Karta[y, x] = ','; //Fyller matrisen med tecknet , så vi får 100 kolumner fyllda 
                    
                }
            }

            foreach (var person in personer) //Fyller matrisen med person objekten 
            {
                if (Karta[person.PosY, person.Posx] == ',') // Om Positionen där objektet ska skrivas ut är täckt med en , symbol överskrids den 
                {
                    Karta[person.PosY, person.Posx] = person.Type; // Överskrider tecknet med symbolen för just det objektet 
                }

            }

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
