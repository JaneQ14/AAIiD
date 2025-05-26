using System;
using System.Collections.Generic;

namespace AAIiD
{
    internal class CW_7
    {
        internal static void Start()
        {
            var graf = new Dictionary<string, List<string>>
            {
                ["A"] = new List<string> { "B", "C" },
                ["B"] = new List<string> { "A", "D", "E" },
                ["C"] = new List<string> { "A", "F" },
                ["D"] = new List<string> { "B", "G" },
                ["E"] = new List<string> { "B", "H" },
                ["F"] = new List<string> { "C", "H" },
                ["G"] = new List<string> { "D", "I" },
                ["H"] = new List<string> { "E", "F", "I" },
                ["I"] = new List<string> { "G", "H", "J" },
                ["J"] = new List<string> { "I" },
                ["K"] = new List<string> { },
            };

            Console.WriteLine("A)\nStruktura grafu (11 wierzchołków):");
            Console.WriteLine("    A\n   / \\\n  B   C\n / \\   \\\nD   E   F\n|    \\ /\nG     H\n \\   /\n   I\n   |\n   J\n");

            Console.WriteLine("Przeszukiwanie grafu od wierzchołka A:\n");

            int bfsSteps = BFS(graf, "A");
            Console.WriteLine($"\nB) BFS wykonał {bfsSteps} kroków.");

            int dfsSteps = DFS(graf, "A");
            Console.WriteLine($"\nC) DFS wykonał {dfsSteps} kroków.");
        }

        static int BFS(Dictionary<string, List<string>> graph, string start)
        {
            var visited = new HashSet<string>();
            var queue = new Queue<string>();
            int steps = 0;

            visited.Add(start);
            queue.Enqueue(start);

            Console.Write("Kolejność odwiedzania (BFS): ");

            while (queue.Count > 0)
            {
                string current = queue.Dequeue();
                Console.Write(current + " ");
                steps++;

                foreach (var neighbor in graph[current])
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);
                    }
                }
            }

            return steps;
        }

        static int DFS(Dictionary<string, List<string>> graph, string start)
        {
            var visited = new HashSet<string>();
            int steps = 0;

            Console.Write("Kolejność odwiedzania (DFS): ");

            void Visit(string node)
            {
                visited.Add(node);
                Console.Write(node + " ");
                steps++;

                foreach (var neighbor in graph[node])
                {
                    if (!visited.Contains(neighbor))
                    {
                        Visit(neighbor);
                    }
                }
            }

            Visit(start);
            return steps;
        }
    }
}
