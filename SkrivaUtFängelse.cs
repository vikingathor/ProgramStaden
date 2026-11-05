using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramStaden
{
    internal class SkrivaUtFängelse
    {
        public int Width { get; set; }
        public int Hight { get; set; }
        public SkrivaUtFängelse()
        {
            Width = 12;
            Hight = 12;
        }


        public void SkrivaUt()
        {
            int X = 55;
            int Y = 26;

            
            for (int i = 0; i < Width; i++)
            {
                Console.SetCursorPosition( X + i , Y);
                Console.Write("=");

                Console.SetCursorPosition(X + i , Y + Hight - 1);
                Console.Write("=");
            }

            for (int i = 0; i < Hight; i++)
            {
                Console.SetCursorPosition( X, Y + i);
                Console.Write("|");

                Console.SetCursorPosition(X + Width - 1, Y + i);
                Console.Write("|");
            }

            Console.SetCursorPosition(X+3,Y-1);
            Console.Write("Fängelse");
            

        }
        
        public void SkrvaUtTjuvar(List<Prison> prisons)
        {
            foreach(var P in prisons)
            {
                Console.SetCursorPosition(P.PosX , P.PosY);
                Console.Write(P.Type);

            }
        }

        public void FlyttaPersoner(List<Prison> prisons)
        {
            foreach (var prison in prisons)
            {

                switch (prison.Where)
                {
                    case 0: //Upp
                        prison.PosY--;
                        break;

                    case 1: //Upp höger 
                        prison.PosY--;
                        prison.PosX++;
                        break;

                    case 2: //Höger
                        prison.PosX++;
                        break;

                    case 3: //Ner höger 
                        prison.PosY++;
                        prison.PosX++;
                        break;

                    case 4: //Ner 
                        prison.PosY++;
                        break;

                    case 5: //Ner vänster 
                        prison.PosY++;
                        prison.PosX--;
                        break;

                    case 6: //Vänster
                        prison.PosX--;
                        break;

                    case 7: //Upp vänster 
                        prison.PosY--;
                        prison.PosX--;
                        break;
                }
                KonstrolleraPositioner(prison);

            }
        }

        public void KonstrolleraPositioner(Prison prison)
        {
            if (prison.PosX >= 66)
                prison.PosX = 56;

            if (prison.PosX < 55)
                prison.PosX = 65;

            if (prison.PosY >= 37)
                prison.PosY = 27;

            if (prison.PosY < 27)
                prison.PosY = 36;
        }
        public void Uppdate(List<Prison> prisons)
        {
            FlyttaPersoner(prisons);

            SkrivaUt();
            SkrvaUtTjuvar(prisons);
           
        }
    }
}
