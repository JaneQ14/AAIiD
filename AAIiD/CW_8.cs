using System;
using System.Collections.Generic;

namespace AAIiD
{
    internal class CW_8
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
                ["J"] = new List<string> { "I" }
            };

            Console.WriteLine("a)\nGraf (10 wierzchołków, zawiera cykle):");
            Console.WriteLine("    A\n   / \\\n  B   C\n / \\   \\\nD   E   F\n|    \\ /\nG     H\n \\   /\n   I\n   |\n   J\n");

            Console.WriteLine("b)\nWyszukiwanie cyklu metodą BFS:");
            int bfsSteps = DetectCycleBFS(graf);
            Console.WriteLine($"Liczba kroków (BFS): {bfsSteps}");

            Console.WriteLine("\nc)\nWyszukiwanie cyklu metodą DFS:");
            int dfsSteps = DetectCycleDFS(graf);
            Console.WriteLine($"Liczba kroków (DFS): {dfsSteps}");
        }

        static int DetectCycleBFS(Dictionary<string, List<string>> graph)
        {
            var visited = new HashSet<string>();
            int steps = 0;

            foreach (var start in graph.Keys)
            {
                if (!visited.Contains(start))
                {
                    var parent = new Dictionary<string, string>();
                    var queue = new Queue<string>();

                    visited.Add(start);
                    queue.Enqueue(start);
                    parent[start] = null;

                    while (queue.Count > 0)
                    {
                        var current = queue.Dequeue();
                        steps++;

                        foreach (var neighbor in graph[current])
                        {
                            if (!visited.Contains(neighbor))
                            {
                                visited.Add(neighbor);
                                queue.Enqueue(neighbor);
                                parent[neighbor] = current;
                            }
                            else if (parent[current] != neighbor)
                            {
                                Console.WriteLine($"Cykl wykryty przy wierzchołku: {current} ↔ {neighbor}");
                                return steps;
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Brak cykli (BFS).");
            return steps;
        }

        static int DetectCycleDFS(Dictionary<string, List<string>> graph)
        {
            var visited = new HashSet<string>();
            int steps = 0;
            bool cycleFound = false;

            void DFS(string node, string parent)
            {
                visited.Add(node);
                steps++;

                foreach (var neighbor in graph[node])
                {
                    if (!visited.Contains(neighbor))
                    {
                        DFS(neighbor, node);
                    }
                    else if (neighbor != parent)
                    {
                        Console.WriteLine($"Cykl wykryty przy wierzchołku: {node} ↔ {neighbor}");
                        cycleFound = true;
                        return;
                    }

                    if (cycleFound) return;
                }
            }

            foreach (var node in graph.Keys)
            {
                if (!visited.Contains(node))
                {
                    DFS(node, null);
                    if (cycleFound) break;
                }
            }

            if (!cycleFound)
                Console.WriteLine("Brak cykli (DFS).");

            return steps;
        }
    }
}
