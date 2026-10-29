using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramStaden
{
    internal class Prison
    {
        public string Name { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int Time { get; set; }

        public Prison(string name)
        {
            Name = name;
            PosX = Random.Shared.Next(0, 10);
            PosY = Random.Shared.Next(0, 10);
            Time = 0;

        }
    }
}
