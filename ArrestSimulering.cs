using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramStaden
{
    internal class ArrestSimulering
    {
     public static void FindTheThiv(List<Program.Personer> personers , List<Prison> prison)
         {
            foreach(var T in personers)
            {
                if ( T is Program.Tjuv && ((Program.Tjuv)T).Inventory.Count > 0)
                {
                    foreach (var P in personers)
                    {
                        if (P is Program.Polis)
                        {
                            if(T.Posx == P.Posx && T.PosY == P.PosY)
                            {
                                ((Program.Polis)P).Inventory.AddRange(((Program.Tjuv)T).Inventory);
                                prison.Add(new Prison(T.Name));
                                personers.Remove(T); 
                            }
                        }
                    }
                }
            }
         }
    }
}
