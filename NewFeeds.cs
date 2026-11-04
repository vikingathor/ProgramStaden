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
                
                for(int i = 0; i  < 4; i++)
                {
                    News.Push(NewsTemp.Pop());
                }


            }
            News.Push(Meddelande);

        }

        public void SkrevUtNews()
        {
            Console.SetCursorPosition(105, 5);
            Console.Write("New Feeds");
            int y = 6;
            foreach (var N in News)
            {
                Console.SetCursorPosition(105,y);
                y++;
                Console.WriteLine(N);
            }
        }
    }
}
