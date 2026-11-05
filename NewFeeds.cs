
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramStaden
{
    internal class NewFeeds
    {
        public Stack<string> News { get; set; }

        public NewFeeds()
        {
            News = new Stack<string>();
        }

        public void AddNews(string Meddelande)
        {
            if (News.Count >= 5)
            {
                Stack<string> NewsTemp = new Stack<string>();

                for (int i = 0; i < 4; i++)
                {
                    NewsTemp.Push(News.Pop());
                }

                News.Pop();

                for (int i = 0; i < 4; i++)
                {
                    News.Push(NewsTemp.Pop());
                }
            }

            News.Push(Meddelande);
        }

        public void SkrevUtNews()
        {
            int X = 105;
            int Y = 5;
            int maxLength = 54;

            Console.SetCursorPosition(X, Y);
            Console.Write("New Feeds");

            int y = Y + 1;

            foreach (var N in News)
            {
                string meddelande = N ?? "";

                // Ta bort radbrytningar i meddelandet
                meddelande = meddelande.Replace("\r", " ")
                                       .Replace("\n", " ");

                // Förkorta långa meddelanden
                // så att de inte hamnar över stadskartan
                if (meddelande.Length > maxLength)
                {
                    meddelande = meddelande.Substring(
                        0, maxLength - 3) + "...";
                }

                Console.SetCursorPosition(X, y);

                // Skriv utan att gå till nästa rad
                Console.Write(meddelande.PadRight(maxLength));

                y++;
            }
        }
    }
}
