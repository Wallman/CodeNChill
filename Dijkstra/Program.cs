using System;
using System.Collections.Generic;

namespace Dijkstra
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Graph graph = new Graph(4);
            graph.AddNodePath(0, 0,  0);
            graph.AddNodePath(0, 1, 20);
            graph.AddNodePath(0, 2, 80);
            graph.AddNodePath(1, 2, 10);
            graph.AddNodePath(2, 3, 20);

            Console.WriteLine(graph.ShortestPath(1));
            Console.WriteLine(graph.ShortestPath(2));
            Console.WriteLine(graph.ShortestPath(3));

        }
    }
}
