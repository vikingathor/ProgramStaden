
using System;
using System.Collections.Generic;

namespace ProgramStaden
{
    internal class StoldSimulering
    {
        public static void FindTheft(List<Program.Personer> personer)
        {
            // Gå igenom alla personer i staden
            foreach (var t in personer)
            {
                // kolla om personen är en tjuv
                if (t is Program.Tjuv tjuv)
                {
                    // Leta efter medborgare
                    foreach (var m in personer)
                    {
                        if (m is Program.Medborgare medborgare)
                        {
                            // kolla om de möts
                            if (tjuv.Posx == medborgare.Posx &&
                                tjuv.PosY == medborgare.PosY)
                            {
                                // Kolla om medborgaren har saker
                                if (medborgare.Inventory.Count > 0)
                                {
                                    // Välj ett slumpmässigt föremål
                                    int index = Random.Shared.Next(
                                        medborgare.Inventory.Count);

                                    string sak = medborgare.Inventory[index];

                                    // Ta saken från medborgaren
                                    medborgare.Inventory.RemoveAt(index);

                                    // Lägg saken hos tjuven
                                    tjuv.Inventory.Add(sak);

                                    // Skriv ut händelsen
                                    Console.WriteLine(
                                        tjuv.Name + " stal " + sak +
                                        " från " + medborgare.Name);

                                    // kolla om medborgaren är utan saker
                                    if (medborgare.Inventory.Count == 0)
                                    {
                                        Console.WriteLine(
                                            medborgare.Name +
                                            " Nu har förlorat alla sina saker och ska till fattighuset.");
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}

