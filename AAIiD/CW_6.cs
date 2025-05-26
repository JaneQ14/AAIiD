using System;
using System.Collections.Generic;

namespace AAIiD
{
    internal class CW_6
    {
        internal static void Start()
        {
            int n = 357;

            Console.WriteLine($"Obliczanie {n}. liczby Fibonacciego:\n");

            // Rekurencja — UWAGA: bardzo wolne dla n>40!
            Console.WriteLine("A)\nRekurencja:");
            stepCounter = 0;
            // Ostrzeżenie: wywołuj tylko dla n <= 40
            int smallN = 30;
            long fibRec = FibRecursive(smallN);
            Console.WriteLine($"F({smallN}) = {fibRec}, kroki: {stepCounter}\n");

            // Memoizacja
            Console.WriteLine("B)\nMemoizacja:");
            stepCounter = 0;
            long fibMemo = FibMemo(n, new Dictionary<int, long>());
            Console.WriteLine($"F({n}) = {fibMemo}, kroki: {stepCounter}\n");

            // Bottom-up
            Console.WriteLine("C)\nBottom-up:");
            long fibBottom = FibBottomUp(n);
            Console.WriteLine($"F({n}) = {fibBottom}, kroki: {stepCounter}");
        }

        static long stepCounter = 0;

        // b) Rekurencyjny algorytm
        public static long FibRecursive(int n)
        {
            stepCounter++;
            if (n <= 1) return n;
            return FibRecursive(n - 1) + FibRecursive(n - 2);
        }

        // c) Memoizacja
        public static long FibMemo(int n, Dictionary<int, long> memo)
        {
            stepCounter++;
            if (memo.ContainsKey(n)) return memo[n];

            if (n <= 1) memo[n] = n;
            else memo[n] = FibMemo(n - 1, memo) + FibMemo(n - 2, memo);

            return memo[n];
        }

        // d) Bottom-up
        public static long FibBottomUp(int n)
        {
            stepCounter = 0;

            if (n == 0) return 0;
            if (n == 1) return 1;

            long[] fib = new long[n + 1];
            fib[0] = 0;
            fib[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                stepCounter++;
                fib[i] = fib[i - 1] + fib[i - 2];
            }

            return fib[n];
        }
    }
}
