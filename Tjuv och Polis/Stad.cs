using System;
using System.Collections.Generic;
using System.Threading;

namespace TjuvOchPolis
{
    public class Stad
    {
        private List<Person> personer = new List<Person>();
        private int[,] karta = new int[100, 25];
        private int antalRånade = 0;
        private int antalGripna = 0;

        public Stad()
        {
            // Lägg till några poliser, tjuvar och medborgare
            for (int i = 0; i < 10; i++) personer.Add(new Polis());
            for (int i = 0; i < 20; i++) personer.Add(new Tjuv());
            for (int i = 0; i < 30; i++) personer.Add(new Medborgare());
        }

        // Kör stadssimuleringen
        public void Starta()
        {
            while (true)
            {
                // Rensa kartan
                ClearKarta();

                // Flytta alla personer
                foreach (var person in personer)
                {
                    person.Move();
                    UppdateraKarta(person);
                }

                // Kolla om någon möter någon annan
                for (int i = 0; i < personer.Count; i++)
                {
                    for (int j = i + 1; j < personer.Count; j++)
                    {
                        if (personer[i].X == personer[j].X && personer[i].Y == personer[j].Y)
                        {
                            if (personer[i] is Polis polis && personer[j] is Tjuv tjuv)
                            {
                                polis.Gripa(tjuv);
                                antalGripna++;
                            }
                            else if (personer[i] is Tjuv tjuv2 && personer[j] is Medborgare medborgare)
                            {
                                tjuv2.Rana(medborgare);
                                antalRånade++;
                            }
                            else if (personer[i] is Medborgare medborgare2 && personer[j] is Tjuv tjuv3)
                            {
                                tjuv3.Rana(medborgare2);
                                antalRånade++;
                            }
                            Thread.Sleep(2000);
                        }
                    }
                }

                // Rita kartan och visa status
                RenderKarta();
                Console.WriteLine($"Antal rånade medborgare: {antalRånade}");
                Console.WriteLine($"Antal gripna tjuvar: {antalGripna}");

                // Pausa lite mellan varje "rörelse"
                Thread.Sleep(500);
            }
        }

        private void ClearKarta()
        {
            for (int x = 0; x < 100; x++)
            {
                for (int y = 0; y < 25; y++)
                {
                    karta[x, y] = 0;
                }
            }
        }

        private void UppdateraKarta(Person person)
        {
            if (person is Polis) karta[person.X, person.Y] = 1;
            else if (person is Tjuv) karta[person.X, person.Y] = 2;
            else if (person is Medborgare) karta[person.X, person.Y] = 3;
        }

        private void RenderKarta()
        {
            Console.Clear();
            for (int y = 0; y < 25; y++)
            {
                for (int x = 0; x < 100; x++)
                {
                    switch (karta[x, y])
                    {
                        case 1: Console.Write("P"); break; // Polis
                        case 2: Console.Write("T"); break; // Tjuv
                        case 3: Console.Write("M"); break; // Medborgare
                        default: Console.Write("."); break; // Tom ruta
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
