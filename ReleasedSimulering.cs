using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramStaden
{
    internal class ReleasedSimulering
    {
        private static int CountTime = 0;
       
        public static void Released(List<Prison> prison , List<Program.Personer> personer , int CountTime , NewFeeds newFeeds)
        {


            for (int i = prison.Count - 1; i >= 0; i--)
            {
                var T = prison[i];
                if(T.StraffTid == CountTime)
                {
                    Program.Tjuv Tjuv = new Program.Tjuv();
                    Tjuv.Name = T.Name;
                    personer.Add(Tjuv);
                    newFeeds.AddNews(Tjuv.Name + "Ska ut från fängelse");
                    prison.RemoveAt(i);
                }
            }

        }
    }
}
