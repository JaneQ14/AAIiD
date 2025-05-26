using System;

namespace AAIiD
{
    internal class CW_4
    {
        internal static void Start()
        {
            //B)
            string[] plik1 = Utils.WczytajSlowaZPliku(Utils.plik1);
            int kroki1 = 0;
            QuickSort(plik1, 0, plik1.Length - 1, ref kroki1);
            Console.WriteLine($"\nB)\nPosortowano {plik1.Length} słów w {kroki1} krokach.");

            //C)
            string[] plik2 = Utils.WczytajSlowaZPliku(Utils.plik2);
            int kroki2 = 0;
            QuickSort(plik2, 0, plik2.Length - 1, ref kroki2);
            Console.WriteLine($"\nC)\nPosortowano {plik2.Length} słów w {kroki2} krokach.");
        }

        static void QuickSort(string[] tablica, int lewy, int prawy, ref int kroki)
        {
            if (lewy < prawy)
            {
                int pivotIndex = Partition(tablica, lewy, prawy, ref kroki);
                QuickSort(tablica, lewy, pivotIndex - 1, ref kroki);
                QuickSort(tablica, pivotIndex + 1, prawy, ref kroki);
            }
        }

        static int Partition(string[] tablica, int lewy, int prawy, ref int kroki)
        {
            string pivot = tablica[prawy];
            int i = lewy - 1;

            for (int j = lewy; j < prawy; j++)
            {
                kroki++; // Zliczamy porównanie
                if (string.Compare(tablica[j], pivot, StringComparison.OrdinalIgnoreCase) <= 0)
                {
                    i++;
                    Zamien(tablica, i, j);
                }
            }

            Zamien(tablica, i + 1, prawy);
            return i + 1;
        }

        static void Zamien(string[] tablica, int i, int j)
        {
            string temp = tablica[i];
            tablica[i] = tablica[j];
            tablica[j] = temp;
        }
    }
}
