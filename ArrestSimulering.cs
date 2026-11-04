using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramStaden
{
    internal class ArrestSimulering
    {
         public static void FindTheThiv(List<Program.Personer> personers , List<Prison> prison , int CountTime , NewFeeds newFeeds)
         {
            //foreach(var T in personers)
            //{
            //    if ( T is Program.Tjuv && ((Program.Tjuv)T).Inventory.Count > 0)
            //    {
            //        foreach (var P in personers)
            //        {
            //            if (P is Program.Polis)
            //            {
            //                if(T.Posx == P.Posx && T.PosY == P.PosY)
            //                {
            //                    ((Program.Polis)P).Inventory.AddRange(((Program.Tjuv)T).Inventory);
            //                    int StraffTid = (((Program.Tjuv)T).Inventory.Count * 10) + CountTime ;
            //                    prison.Add(new Prison(T.Name ,  StraffTid));
            //                    personers.Remove(T); 
            //                }
            //            }
            //        }
            //    }
            //}

            for (int i = personers.Count - 1; i >= 0; i--)
            {
                var T = personers[i];

                if (T is Program.Tjuv thief && thief.Inventory.Count > 0)
                {
                    foreach (var P in personers)
                    {
                        if (P is Program.Polis)
                        {
                            if (T.Posx == P.Posx && T.PosY == P.PosY)
                            {
                                ((Program.Polis)P).Inventory.AddRange(thief.Inventory);

                                int StraffTid = (thief.Inventory.Count * 10) + CountTime;

                                prison.Add(new Prison(T.Name, StraffTid));
                                //Console.WriteLine(P.Name + " Fångad " + thief.Name + " och ska till fängelse ");
                                newFeeds.AddNews(P.Name + " Fångad " + thief.Name + " och ska till fängelse ");
                                personers.RemoveAt(i);
                                break;

                            }
                        }
                    }
                }
            }


        }
    }
}
