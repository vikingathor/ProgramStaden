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
        public int StraffTid { get; set; }
        public char Type { get; set; }
        public int Where { get; set; }

        public Prison(string name , int straffTid)
        {

            Name = name;
            PosX = Random.Shared.Next(56, 67);
            PosY = Random.Shared.Next(27, 37);
            StraffTid = straffTid;
            Type = 'F';
            Where = Random.Shared.Next(0, 8);

        }





    }
}
