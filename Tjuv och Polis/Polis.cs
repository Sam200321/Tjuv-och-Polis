using System;

namespace TjuvOchPolis
{
    public class Polis : Person
    {
        public Polis() : base()
        {
        }

        public void Gripa(Tjuv tjuv)
        {
            if (tjuv.Inventory.Count > 0)
            {
                Console.WriteLine("Polis tar tjuv och beslagtar alla stulna saker.");
                Inventory.AddRange(tjuv.Inventory);
                tjuv.Inventory.Clear();
            }
        }
    }
}
