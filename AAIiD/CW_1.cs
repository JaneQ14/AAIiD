using System;
using System.Linq;

namespace AAIiD
{
    internal class CW_1
    {
        internal static void Start()
        {
            //b)
            var plik1 = Utils.WczytajSlowaZPliku(Utils.plik1);
            char[] litery = { 'a', 'c', 'd', 'm', 'w', 'z' };

            Console.WriteLine("\nB)\nWyszukiwanie liniowe dla liter: a, c, d, m, w, z");

            foreach (char litera in litery)
            {
                string slowo = plik1.FirstOrDefault(s => s.StartsWith(litera.ToString(), StringComparison.OrdinalIgnoreCase));

                if (slowo != null)
                {
                    int kroki;
                    WyszukiwanieLiniowe(plik1, slowo, out kroki);
                    Console.WriteLine($"Słowo zaczynające się na '{litera}': \"{slowo}\" znalezione po {kroki} krokach.");
                }

                else
                {
                    Console.WriteLine($"Brak słowa na literę '{litera}' w pliku");
                }
            }

            //c)
            var plik2 = Utils.WczytajSlowaZPliku(Utils.plik2);
            string ostatnieSlowo = plik2.Last();
            int krokiDoOstatniego;
            WyszukiwanieLiniowe(plik2, ostatnieSlowo, out krokiDoOstatniego);
            Console.WriteLine($"\nC)\nOstatnie słowo \"{ostatnieSlowo}\" – znalezione w {krokiDoOstatniego} krokach");
        }

        static int WyszukiwanieLiniowe(string[] dane, string szukaneSlowo, out int kroki)
        {
            kroki = 0;

            for (int i = 0; i < dane.Length; i++)
            {
                kroki++;

                if (dane[i].Equals(szukaneSlowo, StringComparison.OrdinalIgnoreCase))
                {
                    return i; 
                }
            }
            return -1; // Nie znaleziono 
        }
    }
}