using System;

namespace TjuvOchPolis
{
    public class Tjuv : Person
    {
        public Tjuv() : base()
        {
        }

        public void Rana(Medborgare medborgare)
        {
            if (medborgare.Inventory.Count > 0)
            {
                Random rand = new Random();
                int index = rand.Next(medborgare.Inventory.Count);
                string stulenSak = medborgare.Inventory[index];
                medborgare.Inventory.RemoveAt(index);
                Inventory.Add(stulenSak);
                Console.WriteLine($"Tjuv rånar medborgare och tar {stulenSak}.");
            }
        }
    }
}
