using System;
using System.Collections.Generic;
using System.Linq;

namespace AAIiD
{
    internal class CW_10
    {
        internal static void Start()
        {
            string[] imiona = {
                "Karina", "Jan", "Katsiaryna", "Dawid", "Marcin", "Wiktor",
                "Krystian", "Jakub", "Marta", "Bernard", "Grzegorz", "Piotr",
                "Jakub", "Michał", "Mikołaj", "Kamil", "Tomasz", "Paweł",
                "Adrian", "Jan"
            };

            string[] nazwiska = {
                "Rataj", "Rogowski", "Rudskaya", "Sikorski", "Skopiński", "Sobczyk",
                "Sosnowski", "Stafijowski", "Stepanik", "Szynkora", "Tokaj", "Trepka",
                "Trzaskowski", "Trzosowski", "Ustymowicz", "Wasilewski", "Wiktorowski", "Zajczyk",
                "Zalewski", "Żegota"
            };

            Console.WriteLine("a) SoundEx – porównanie imion:\n");
            PorownajSoundEx(imiona);

            Console.WriteLine("\nSoundEx – porównanie nazwisk:\n");
            PorownajSoundEx(nazwiska);

            Console.WriteLine("\nc/d) Levenshtein – porównanie imion:\n");
            PorownajLevenshtein(imiona);

            Console.WriteLine("\nLevenshtein – porównanie nazwisk:\n");
            PorownajLevenshtein(nazwiska);
        }

        static string SoundEx(string word)
        {
            if (string.IsNullOrWhiteSpace(word)) return "";

            word = word.ToUpperInvariant();
            char firstLetter = word[0];

            // Mapowanie liter na cyfry
            Dictionary<char, char> map = new Dictionary<char, char>()
            {
                ['B'] = '1',
                ['F'] = '1',
                ['P'] = '1',
                ['V'] = '1',
                ['C'] = '2',
                ['G'] = '2',
                ['J'] = '2',
                ['K'] = '2',
                ['Q'] = '2',
                ['S'] = '2',
                ['X'] = '2',
                ['Z'] = '2',
                ['D'] = '3',
                ['T'] = '3',
                ['L'] = '4',
                ['M'] = '5',
                ['N'] = '5',
                ['R'] = '6',
            };

            // 1. Zamień litery (łącznie z pierwszą) na cyfry
            var encoded = new List<char>();
            foreach (char c in word)
            {
                if (map.TryGetValue(c, out char digit))
                {
                    encoded.Add(digit);
                }
                else
                {
                    encoded.Add('0');
                }
            }

            // 2. Zachowaj pierwszą literę i usuń powtórzenia cyfr
            var digits = new List<char>();
            char? previous = null;
            foreach (char digit in encoded)
            {
                if (digit != previous)
                {
                    digits.Add(digit);
                    previous = digit;
                }
            }

            // 3. Usuń wszystkie zera (samogłoski i H, W, Y)
            digits.RemoveAll(d => d == '0');

            // 4. Jeśli pierwsza zakodowana cyfra = cyfra dla pierwszej litery → usuń ją
            if (digits.Count > 0 && map.TryGetValue(firstLetter, out char firstLetterCode) && digits[0] == firstLetterCode)
            {
                digits.RemoveAt(0);
            }

            // 5. Zbuduj wynik
            string code = firstLetter + string.Concat(digits);
            code = code.PadRight(4, '0').Substring(0, 4);
            return code;
        }

        static void PorownajSoundEx(string[] words)
        {
            for (int i = 0; i < words.Length; i++)
            {
                string code1 = SoundEx(words[i]);
                for (int j = i + 1; j < words.Length; j++)
                {
                    string code2 = SoundEx(words[j]);
                    if (code1 == code2)
                    {
                        Console.WriteLine($"{words[i]} ↔ {words[j]} → kod: {code1}");
                    }
                }
            }
        }

        static int Levenshtein(string a, string b)
        {
            int[,] dp = new int[a.Length + 1, b.Length + 1];

            for (int i = 0; i <= a.Length; i++)
                dp[i, 0] = i;

            for (int j = 0; j <= b.Length; j++)
                dp[0, j] = j;

            for (int i = 1; i <= a.Length; i++)
            {
                for (int j = 1; j <= b.Length; j++)
                {
                    int cost = a[i - 1] == b[j - 1] ? 0 : 1;
                    dp[i, j] = Math.Min(Math.Min(
                        dp[i - 1, j] + 1,
                        dp[i, j - 1] + 1),
                        dp[i - 1, j - 1] + cost);
                }
            }

            return dp[a.Length, b.Length];
        }

        static void PorownajLevenshtein(string[] words)
        {
            var grupy = new Dictionary<int, List<(string, string)>>();

            for (int i = 0; i < words.Length; i++)
            {
                for (int j = i + 1; j < words.Length; j++)
                {
                    int dist = Levenshtein(words[i], words[j]);
                    if (!grupy.ContainsKey(dist))
                        grupy[dist] = new List<(string, string)>();

                    grupy[dist].Add((words[i], words[j]));
                }
            }

            foreach (var grupa in grupy.OrderBy(g => g.Key))
            {
                Console.WriteLine($"\nOdległość Levenshteina = {grupa.Key}:");
                foreach (var para in grupa.Value)
                {
                    Console.WriteLine($"  {para.Item1} ↔ {para.Item2}");
                }
            }
        }
    }
}