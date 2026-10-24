using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ProgramStaden
{
    internal class Staden
    {
        public List<Program.Personer> personer { get; set; }

        public void City()
        {
            personer = new List<Program.Personer>(); //EN ny lista med objekten från personer

            for (int i = 0; i < 20;  i++)
            {
                personer.Add(new Program.Medborgare());
            }

            for (int i = 0;i < 20;i++)
            {
                personer.Add(new Program.Polis());
            }
            for (int i = 0; i<20 ; i++)
            {
                personer.Add(new Program.Tjuv());
            }
        }

        
    }
}
