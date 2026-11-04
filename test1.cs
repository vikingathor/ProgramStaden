using System;
using System.Collections.Generic;

namespace ProgramStaden
{
    internal class Fattighuset
    {
        public string Name { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public char Type { get; set; } = 'F';

        public Fattighuset(string name)
        {
            Name = name;

            // Slumpmässig position i Fattighuset
            PosX = Random.Shared.Next(0, 50);
            PosY = Random.Shared.Next(0, 10);
        }
    }

    internal class FattighusSimulering
    {
        private const int Width = 50;
        private const int Height = 10;

        // Flyttar medborgare utan saker till Fattighuset
        public static void FlyttaTillFattighuset(
            List<Program.Personer> personer,
            List<Fattighuset> fattighus)
        {
            // Gå baklänges eftersom vi tar bort personer
            for (int i = personer.Count - 1; i >= 0; i--)
            {
                if (personer[i] is Program.Medborgare medborgare)
                {
                    if (medborgare.Inventory.Count == 0)
                    {
                        // Behåll personens befintliga namn
                        fattighus.Add(
                            new Fattighuset(medborgare.Name));

                        // Ta bort medborgaren från staden
                        personer.RemoveAt(i);
                    }
                }
            }
        }

        // Flytta alla personer i Fattighuset
        public static void Uppdatera(
            List<Fattighuset> fattighus)
        {
            foreach (var person in fattighus)
            {
                int riktning = Random.Shared.Next(0, 8);

                switch (riktning)
                {
                    case 0:
                        person.PosY--;
                        break;

                    case 1:
                        person.PosY--;
                        person.PosX++;
                        break;

                    case 2:
                        person.PosX++;
                        break;

                    case 3:
                        person.PosY++;
                        person.PosX++;
                        break;

                    case 4:
                        person.PosY++;
                        break;

                    case 5:
                        person.PosY++;
                        person.PosX--;
                        break;

                    case 6:
                        person.PosX--;
                        break;

                    case 7:
                        person.PosY--;
                        person.PosX--;
                        break;
                }

                // Kom tillbaka på motsatt sida av kartan
                if (person.PosX >= Width)
                    person.PosX = 0;

                if (person.PosX < 0)
                    person.PosX = Width - 1;

                if (person.PosY >= Height)
                    person.PosY = 0;

                if (person.PosY < 0)
                    person.PosY = Height - 1;
            }
        }

        // Rita ut Fattighuset direkt i konsolen
        public static void Utskrift(
            List<Fattighuset> fattighus)
        {
            char[,] karta = new char[Height, Width];

            // Skapa en tom karta
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    karta[y, x] = ' ';
                }
            }

            // Placera alla F på kartan
            foreach (var person in fattighus)
            {
                karta[person.PosY, person.PosX] = person.Type;
            }

            Console.WriteLine("===== FATTIGHUSET =====");

            Console.WriteLine("+" + new string('-', Width) + "+");

            for (int y = 0; y < Height; y++)
            {
                Console.Write("|");

                for (int x = 0; x < Width; x++)
                {
                    Console.Write(karta[y, x]);
                }

                Console.WriteLine("|");
            }

            Console.WriteLine("+" + new string('-', Width) + "+");

            Console.WriteLine(
                "Antal personer i Fattighuset: " + fattighus.Count);
        }
    }
}