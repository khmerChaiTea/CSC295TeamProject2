using System;

namespace CSC295TeamProject2
{
    public class DisjointSet
    {
        private int[] parent; // Array to hold the parent of each element
        private int[] rank;   // Array to hold the rank (depth) of each tree

        public DisjointSet(int size)
        {
            parent = new int[size]; // Initialize parent array
            rank = new int[size];   // Initialize rank array
            for (int i = 0; i < size; i++)
            {
                parent[i] = i; // Each element is its own parent (root of itself)
                rank[i] = 0;   // Initial rank is zero
            }
        }

        // Find the representative (root) of the set that element x is in
        public int Find(int x)
        {
            if (parent[x] != x)
            {
                parent[x] = Find(parent[x]); // Path compression: make the parent point to the root
            }
            return parent[x];
        }

        // Union of two sets containing elements x and y
        public void Union(int x, int y)
        {
            int rootX = Find(x); // Find root of x
            int rootY = Find(y); // Find root of y

            if (rootX != rootY)
            {
                if (rank[rootX] > rank[rootY])
                {
                    parent[rootY] = rootX; // Make rootX the parent of rootY
                }
                else if (rank[rootX] < rank[rootY])
                {
                    parent[rootX] = rootY; // Make rootY the parent of rootX
                }
                else
                {
                    parent[rootY] = rootX; // Make rootX the parent of rootY
                    rank[rootX]++;        // Increase the rank of rootX
                }
            }
        }

        // Check if two elements are in the same set
        public bool Connected(int x, int y)
        {
            return Find(x) == Find(y); // Check if both elements have the same root
        }

        public void PrintSets()
        {
            Console.WriteLine("Current sets:");
            for (int i = 0; i < parent.Length; i++)
            {
                Console.WriteLine($"Element {i}: Root = {Find(i)}");
            }
            Console.WriteLine();
        }
    }
}
