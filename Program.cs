
static void StealFromCitizen(Tjuv thief, Medborgare citizen)
{
    // Kontrollera om medborgaren har något att stjäla
    if (citizen.Inventory.Count == 0)
    {
        return;
    }

    // Välj ett slumpmässigt föremål
    int index = Random.Shared.Next(citizen.Inventory.Count);

    string item = citizen.Inventory[index];

    // Ta bort föremålet från medborgaren
    citizen.Inventory.RemoveAt(index);

    // Lägg till föremålet hos tjuven
    thief.Inventory.Add(item);
}
