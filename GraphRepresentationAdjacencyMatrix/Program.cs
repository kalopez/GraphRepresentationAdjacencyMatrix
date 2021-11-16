using System;
using System.Collections.Generic;

namespace GraphRepresentationAdjacencyMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            //Adjacency Matrix is best for dense graphs with number of edges close to the number of vertices.
            //Create vertex list
            List<char> vertices = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };

            //Create matrix
            List<List<int>> matrix = new List<List<int>>();
            matrix.Add(new List<int>() { 0, 1, 1, 1, 0, 0, 0, 0 });
            matrix.Add(new List<int>() { 1, 0, 0, 0, 1, 1, 0, 0 });
            matrix.Add(new List<int>() { 1, 0, 0, 0, 0, 0, 1, 0 });
            matrix.Add(new List<int>() { 1, 0, 0, 0, 0, 0, 0, 1 });
            matrix.Add(new List<int>() { 0, 1, 0, 0, 0, 0, 0, 1 });
            matrix.Add(new List<int>() { 0, 1, 0, 0, 0, 0, 0, 1 });
            matrix.Add(new List<int>() { 0, 0, 1, 0, 0, 0, 0, 1 });
            matrix.Add(new List<int>() { 0, 0, 0, 1, 1, 1, 1, 0 });

            PrintAdjacencyMatrix(matrix, vertices);

            //Allow user to decide whether to exit, find adjacent nodes or find if two nodes are connected
            Console.WriteLine("\nPress 'Esc' to exit the process\n Press'S' to find a node's neighbors\n Press 'T' to find if two nodes are connected");
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            //Exit console
            if (keyInfo.Key == ConsoleKey.Escape)
                Environment.Exit(0);

            //Find adjacent nodes
            while (keyInfo.Key == ConsoleKey.S)
            {
                Console.WriteLine();
                Console.WriteLine("Enter a specific node to find its neighbors");
                //char[] nodes = Console.ReadLine().ToCharArray();
                char node = Console.ReadLine().ToUpper().ToCharArray()[0];
                int vertexNumber = vertices.IndexOf(node);
                List<int> connectionList = matrix[vertexNumber];
                for (int i = 0; i < connectionList.Count; i++)
                {
                    if (connectionList[i] == 1)
                        Console.Write(vertices[i] + " ");
                }
                Console.WriteLine();
                Console.WriteLine("\nPress 'Esc' to exit the process\n Press'S' to find a node's neighbors\n Press 'T' to find if two nodes are connected");
                keyInfo = Console.ReadKey(true);
            }

            //Find if two nodes are connected
            while (keyInfo.Key == ConsoleKey.T)
            {
                Console.WriteLine();
                Console.WriteLine("Enter two nodes with no space in between find out if they are connected");
                char[] nodes = Console.ReadLine().ToUpper().ToCharArray();
                int vertexNumber1 = vertices.IndexOf(nodes[0]);
                int vertexNumber2 = vertices.IndexOf(nodes[1]);
                List<int> node1ConnectionList = matrix[vertexNumber1];
                if (node1ConnectionList[vertexNumber2] == 1)
                    Console.WriteLine("Yes, they are connected");
                else
                    Console.WriteLine("No, they are not connected");

                Console.WriteLine("\nPress 'Esc' to exit the process\n Press'S' to find a node's neighbors\n Press 'T' to find if two nodes are connected");
                keyInfo = Console.ReadKey(true);
            }
        }

        public static void PrintAdjacencyMatrix(List<List<int>> matrix, List<char> vertices)
        {
            //print vertices' names
            Console.Write("  ");
            foreach (char vertex in vertices)
                Console.Write(vertex);
            Console.WriteLine();

            //print adjacency matrix
            for (int i = 0; i < matrix.Count; i++)
            {
                Console.Write(vertices[i] + " ");

                for (int j = 0; j < matrix.Count; j++)
                {
                    Console.Write(matrix[i][j]);
                }
                Console.WriteLine();
            }
        }

    }
}
