using System;
using System.Linq;

namespace AAIiD
{
    internal class CW_2
    {
        internal static void Start()
        {
            //b)
            char[] litery = { 'a', 'c', 'd', 'm', 'w', 'z' };
            string[] plik1 = Utils.WczytajSlowaZPliku(Utils.plik1);

            Console.WriteLine("\nB)\nWyszukiwanie binarne dla liter: a, c, d, m, w, z");

            foreach (var litera in litery)
            {
                string slowo = plik1.FirstOrDefault(s => s.StartsWith(litera.ToString(), StringComparison.OrdinalIgnoreCase));
                
                if (slowo != null)
                {
                    int kroki;
                    WyszukiwanieBinarne(plik1, slowo, out kroki);
                    Console.WriteLine($"Szukane słowo zaczynające się na '{litera}': \"{slowo}\" – znalezione po {kroki} krokach");
                }
                else
                {
                    Console.WriteLine($"Brak słowa na literę '{litera}' w pliku");
                }
            }

            //c)
            string[] plik2 = Utils.WczytajSlowaZPliku(Utils.plik2);
            string ostatnieSlowo = plik2.Last();
            int krokiDoOstatniego;
            WyszukiwanieBinarne(plik2, ostatnieSlowo, out krokiDoOstatniego);
            Console.WriteLine($"\nC)\nOstatnie słowo \"{ostatnieSlowo}\" – znalezione w {krokiDoOstatniego} krokach");
        }

        static int WyszukiwanieBinarne(string[] tablica, string szukane, out int kroki)
        {
            int lewy = 0;
            int prawy = tablica.Length - 1;
            kroki = 0;

            while (lewy <= prawy)
            {
                kroki++;
                int srodek = (lewy + prawy) / 2;
                int porownanie = string.Compare(szukane, tablica[srodek], StringComparison.OrdinalIgnoreCase);

                if (porownanie == 0)
                {
                    return kroki;
                }
                else if (porownanie < 0)
                {
                    prawy = srodek - 1;
                }
                else
                {
                    lewy = srodek + 1;
                }
            }

            return kroki;
        }
    }
}