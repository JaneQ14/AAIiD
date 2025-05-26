using System;
using System.Collections.Generic;
using System.Linq;

namespace AAIiD
{
    internal class CW_9
    {
        internal static void Start()
        {
            var words = Utils.WczytajSlowaZPliku(Utils.plik2).OrderBy(w => w).ToArray();

            Console.WriteLine($"a)\nWczytano {words.Length} słów i posortowano.\n");

            if (words.Length < 1000)
            {
                Console.WriteLine("\nBłąd: plik musi zawierać co najmniej 1000 słów.");
                return;
            }

            var queue = new Queue<string>(words);

            // b) usunięcie elementów od 100 do 200 (indeksy 99–199)
            var tempList = queue.ToList();
            tempList.RemoveRange(99, 101); // usuń 101 elementów od indeksu 99 do 199

            queue = new Queue<string>(tempList);

            // c) wyświetlenie zawartości kolejki
            Console.WriteLine("c)\nZawartość kolejki po usunięciu elementów 100–200:\n");

            int index = 1;
            foreach (var word in queue)
            {
                Console.Write($"{word} ");
                if (index++ % 20 == 0) Console.WriteLine(); // nowa linia co 20 słów
            }

            Console.WriteLine($"\n\nLiczba pozostałych elementów: {queue.Count}");
        }
    }
}