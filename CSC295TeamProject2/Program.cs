using System;
using System.Collections.Generic;

namespace CSC295TeamProject2
{
    public class NetworkConnectivity
    {
        public static void Main()
        {
            int n = 5; // Number of nodes in the network
            DisjointSet ds = new DisjointSet(n); // Initialize the Disjoint Set

            // List of existing connections between nodes
            List<Tuple<int, int>> connections = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, 1),
                new Tuple<int, int>(1, 2),
                new Tuple<int, int>(2, 3)
                // Note: The connection (3, 4) is removed to create a scenario where adding (1, 4) does not form a cycle
            };

            // Union operation for each existing connection
            foreach (var connection in connections)
            {
                ds.Union(connection.Item1, connection.Item2);
                Console.WriteLine($"Connecting {connection.Item1} and {connection.Item2}");
            }

            ds.PrintSets(); // Print the current sets

            // New connection to be added
            Tuple<int, int> newConnection1 = new Tuple<int, int>(1, 4);

            // Check if the new connection would form a cycle
            if (ds.Connected(newConnection1.Item1, newConnection1.Item2))
            {
                Console.WriteLine($"Adding the new connection between {newConnection1.Item1} and {newConnection1.Item2} would form a cycle.");
            }
            else
            {
                Console.WriteLine($"Adding the new connection between {newConnection1.Item1} and {newConnection1.Item2} would not form a cycle.");
                ds.Union(newConnection1.Item1, newConnection1.Item2); // Union operation for the new connection
                Console.WriteLine($"Connecting {newConnection1.Item1} and {newConnection1.Item2}");
            }

            ds.PrintSets(); // Print the updated sets

            // Another new connection to be added that does not form a cycle
            Tuple<int, int> newConnection2 = new Tuple<int, int>(3, 4);

            // Check if the new connection would form a cycle
            if (ds.Connected(newConnection2.Item1, newConnection2.Item2))
            {
                Console.WriteLine($"Adding the new connection between {newConnection2.Item1} and {newConnection2.Item2} would form a cycle.");
            }
            else
            {
                Console.WriteLine($"Adding the new connection between {newConnection2.Item1} and {newConnection2.Item2} would not form a cycle.");
                ds.Union(newConnection2.Item1, newConnection2.Item2); // Union operation for the new connection
                Console.WriteLine($"Connecting {newConnection2.Item1} and {newConnection2.Item2}");
            }

            ds.PrintSets(); // Print the updated sets again
        }
    }
}
