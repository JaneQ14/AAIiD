using System;

namespace AAIiD
{
    internal class CW_5
    {
        internal static void Start()
        {
            Console.WriteLine("A)\nDodawanie macierzy:");
            TestAddition(2);
            TestAddition(3);
            TestAddition(4);
            TestAddition(5);

            Console.WriteLine("\nB)\nMnożenie macierzy:");
            TestMultiplication(2, 3, 3, 4);
            TestMultiplication(3, 4, 4, 5);
            TestMultiplication(4, 5, 5, 4);
            TestMultiplication(4, 5, 4, 5); // Błędne wymiary do mnożenia – zostanie obsłużone

            Console.WriteLine("\nC)\nTranspozycja macierzy:");
            int[,] matrix = GenerateMatrix(3, 2);
            PrintMatrix(matrix);
            int[,] transposed = TransposeMatrix(matrix, out int transKroki);
            Console.WriteLine("\nPo transpozycji:");
            PrintMatrix(transposed);
            Console.WriteLine($"\nLiczba kroków: {transKroki}");
        }

        static void TestAddition(int size)
        {
            int[,] A = GenerateMatrix(size, size);
            int[,] B = GenerateMatrix(size, size);
            int[,] result = AddMatrices(A, B, out int steps);
            Console.WriteLine($"Dodano dwie macierze {size}x{size} w {steps} krokach.");
        }

        static void TestMultiplication(int r1, int c1, int r2, int c2)
        {
            if (c1 != r2)
            {
                Console.WriteLine($"Nie można pomnożyć macierzy {r1}x{c1} i {r2}x{c2} – niezgodne wymiary.");
                return;
            }

            int[,] A = GenerateMatrix(r1, c1);
            int[,] B = GenerateMatrix(r2, c2);
            int[,] result = MultiplyMatrices(A, B, out int steps);
            Console.WriteLine($"Pomnożono macierze {r1}x{c1} i {r2}x{c2} w {steps} krokach.");
        }

        static int[,] GenerateMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];
            Random rand = new Random();
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    matrix[i, j] = rand.Next(1, 10);
            return matrix;
        }

        static int[,] AddMatrices(int[,] A, int[,] B, out int steps)
        {
            int rows = A.GetLength(0);
            int cols = A.GetLength(1);
            int[,] result = new int[rows, cols];
            steps = 0;

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = A[i, j] + B[i, j];
                    steps++;
                }

            return result;
        }

        static int[,] MultiplyMatrices(int[,] A, int[,] B, out int steps)
        {
            int rowsA = A.GetLength(0);
            int colsA = A.GetLength(1);
            int colsB = B.GetLength(1);
            int[,] result = new int[rowsA, colsB];
            steps = 0;

            for (int i = 0; i < rowsA; i++)
                for (int j = 0; j < colsB; j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < colsA; k++)
                    {
                        result[i, j] += A[i, k] * B[k, j];
                        steps++;
                    }
                }

            return result;
        }

        static int[,] TransposeMatrix(int[,] matrix, out int steps)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[,] transposed = new int[cols, rows];
            steps = 0;

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                {
                    transposed[j, i] = matrix[i, j];
                    steps++;
                }

            return transposed;
        }

        static void PrintMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                    Console.Write(matrix[i, j] + " ");
                Console.WriteLine();
            }
        }
    }
}
