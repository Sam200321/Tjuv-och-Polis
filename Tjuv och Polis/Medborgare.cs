using System;

namespace TjuvOchPolis
{
    public class Medborgare : Person
    {
        public Medborgare()
        {
            Inventory.Add("Nycklar");
            Inventory.Add("Mobiltelefon");
            Inventory.Add("Pengar");
            Inventory.Add("Klocka");
        }
    }
}
