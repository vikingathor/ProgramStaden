using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramStaden
{
    internal class ReleasedSimulering
    {

        public static void Released(List<Prison> prison , List<Program.Personer> personer)
        {
            foreach(var T in prison)
            {
                if (T.Time == T.StraffTid)
                {
                    Program.Tjuv Tjuv = new Program.Tjuv();
                    Tjuv.Name = T.Name;
                    personer.Add(Tjuv);
                    
                }
            }
        }
    }
}
