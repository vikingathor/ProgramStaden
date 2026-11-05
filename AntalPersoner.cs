using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramStaden
{
    internal class AntalPersoner
    {

        public  static void antalPersoner(List<Program.Personer>personers , List<Prison> prisons , List<Fattighuset> fattighusets)
        {
            int AntalMedborgare = 0;
            int AntalTjuvar = 0;
            int AntalPoliser = 0;
            int AntalFångar = 0;
            int AntalFattiga = 0;

            foreach (var M in personers)
            {
                if(M is Program.Medborgare)
                {
                    AntalMedborgare++;
                }
                if (M is Program.Polis)
                {
                    AntalPoliser++;
                }
                if (M is Program.Tjuv)
                {
                    AntalTjuvar++;
                }
                

            }
            AntalFattiga =  fattighusets.Count();
            AntalFångar = prisons.Count();

           


            Console.SetCursorPosition(105,12);
            Console.Write("Antal ");
            Console.SetCursorPosition(105, 13);
            Console.Write("Antal Medborgare : " + AntalMedborgare);
            Console.SetCursorPosition(105, 14);
            Console.Write("Antal Poliser : " + AntalPoliser);
            Console.SetCursorPosition(105, 15);
            Console.Write("Antal Tjuvar : " + AntalTjuvar);
            Console.SetCursorPosition(105, 16);
            Console.Write("Antal Fångar : " + AntalFångar);
            Console.SetCursorPosition(105, 17);
            Console.Write("Antal Fattiga : " + AntalFattiga);

        }
    }
}
