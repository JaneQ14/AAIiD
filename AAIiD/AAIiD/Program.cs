using System;
using System.IO;
using System.Linq;

namespace AAIiD
{
    internal static class Utils
    {
        //pliki z artykułami i językiem inny niż polski 
        internal static string plik1 = "plik1.txt";
        internal static string plik2 = "plik2.txt";

        internal static string[] WczytajSlowaZPliku(string sciezka)
        {
            if (!File.Exists(sciezka))
            {
                Console.WriteLine($"Nie znaleziono pliku: {sciezka}");
                return Array.Empty<string>();
            }

            var slowa = File.ReadAllText(sciezka)
                .Split(new char[] { ' ', '\n', '\r', '\t', '.', ',', ';', ':', '!', '?', '\"', '(', ')', '[', ']' },
                StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.ToLower())
                .ToArray();

            //Console.WriteLine($"Wczytano {slowa.Length} słów z pliku '{sciezka}'");
            return slowa;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\tĆwiczenie nr 1 – algorytm wyszukiwania liniowego");
            Console.ResetColor();
            CW_1.Start();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n\tĆwiczenie nr 2 – algorytm wyszukiwania binarnego");
            Console.ResetColor();
            CW_2.Start();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n\tĆwiczenie nr 3 – algorytm sortowania przez wybór");
            Console.ResetColor();
            CW_3.Start();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n\tĆwiczenie nr 4 – algorytm sortowania szybkiego");
            Console.ResetColor();
            CW_4.Start();
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n\tĆwiczenie nr 5 – algorytmy operacji na macierzy");
            Console.ResetColor();
            CW_5.Start();
            
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n\tĆwiczenie nr 6 – obliczanie liczby Fibonacciego");
            Console.ResetColor();
            CW_6.Start();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n\tĆwiczenie nr 7 – przeszukiwanie grafu");
            Console.ResetColor();
            CW_7.Start();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n\tĆwiczenie nr 8 – wyszukiwanie cykli w grafie");
            Console.ResetColor();
            CW_8.Start();
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n\tĆwiczenie nr 9 – operacje na kolejkach");
            Console.ResetColor();
            CW_9.Start();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n\tĆwiczenie nr 10 – algorytmy geometryczne");
            Console.ResetColor();
            CW_10.Start();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n\tĆwiczenie nr 11 – algorytmy geometryczne");
            Console.ResetColor();
            CW_11.Start();

            Console.WriteLine();
        }
    }
}
