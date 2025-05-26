using System;

namespace AAIiD
{
    internal class CW_3
    {
        internal static void Start()
        {
            //b)
            string[] plik1 = Utils.WczytajSlowaZPliku(Utils.plik1);
            int kroki1 = SelectionSort(plik1);
            Console.WriteLine($"\nB)\nPosortowano {plik1.Length} słów w {kroki1} krokach.");

            //c)
            string[] plik2 = Utils.WczytajSlowaZPliku(Utils.plik2);
            int kroki2 = SelectionSort(plik2);
            Console.WriteLine($"\nC)\nPosortowano {plik2.Length} słów w {kroki2} krokach.");
        }

        static int SelectionSort(string[] tablica)
        {
            int kroki = 0;
            int n = tablica.Length;

            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < n; j++)
                {
                    kroki++;
                    if (string.Compare(tablica[j], tablica[minIndex], StringComparison.OrdinalIgnoreCase) < 0)
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    string temp = tablica[i];
                    tablica[i] = tablica[minIndex];
                    tablica[minIndex] = temp;
                }
            }

            return kroki;
        }
    }
}
