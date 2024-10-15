using System.Collections.Generic;

namespace TjuvOchPolis
{
    public abstract class Person
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int XDirection { get; set; }
        public int YDirection { get; set; }
        public List<string> Inventory { get; set; }

        public Person()
        {
            Random rand = new Random();
            X = rand.Next(0, 100);
            Y = rand.Next(0, 25);
            XDirection = rand.Next(-1, 2); // -1, 0 eller 1
            YDirection = rand.Next(-1, 2); // -1, 0 eller 1
            Inventory = new List<string>();
        }

        public void Move()
        {
            X += XDirection;
            Y += YDirection;

            if (X < 0) X = 99;
            if (X > 99) X = 0;
            if (Y < 0) Y = 24;
            if (Y > 24) Y = 0;
        }
    }
}
