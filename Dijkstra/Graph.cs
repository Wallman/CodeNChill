using System;
using System.Collections.Generic;
using System.Linq;

namespace Dijkstra
{
    class Graph
    {
        public int[ , ] nodePaths { get; private set; }

        public Graph(int capacity)
        {
            int[ , ] C = new int[capacity, capacity];
            nodePaths = C;
            InitArr(C);
        }

        /// <summary>
        /// Initializes the array with int.MaxValue for all elements.
        /// </summary>
        /// <param name="arr">Arr.</param>
        private void InitArr(int[,] arr)
        {
            for(int i = 0; i < arr.GetLength(0); i++)
            {
                for(int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = int.MaxValue;
                }
            }
        }

        private void InitArr(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.MaxValue;
            }
        }

        /// <summary>
        /// Adds a nodepath between origin and target with a cost.
        /// </summary>
        /// <param name="origin">Origin.</param>
        /// <param name="target">Target.</param>
        /// <param name="cost">Cost.</param>
        public void AddNodePath(int origin, int target, int cost)
        {
            nodePaths[origin, target] = cost;
        }

        public void Print()
        {
            foreach(int node in nodePaths)
            {
                Console.WriteLine(node);
            }
        }

        public int ShortestPath(int target)
        {
            return Dijkstra(nodePaths)[target];
        }

        /// <summary>
        /// Use Dijkstra's algorithm to find shortest paths between vertex 0 -> all.
        /// </summary>
        /// <param name="C">C.</param>
        private int[] Dijkstra(int[ , ] C)
        {
            int numOfNodes = C.GetLength(0);
            int[] D = new int[numOfNodes]; // Shortest paths
            int[] S = new int[numOfNodes]; // Done vertexes
            int sPtr = 0;
            int index = 0;
            InitArr(D);
            InitArr(S);
            D[0] = 0;

            while(index != -1) // Hur många gånger vi totalt ska iterera, byt till while?
            {
                S[sPtr] = index;
                sPtr++;
                for(int j = 1; j < numOfNodes; j++) // Inre loop för att kolla alla vägar.
                {
                    if(C[index, j] != int.MaxValue && !S.Contains(j))
                    {
                        if((C[index, j] + D[index]) < D[j])
                        {
                            D[j] = C[index, j] + D[index];
                        }
                    }
                }
                index = Min(D, S);
            }
            return D;
        }

        /// <summary>
        /// Return index of shortest path in D - S;
        /// </summary>
        public int Min(int[] D, int[] S)
        {
            int index = -1;
            for (int i = 1; i < D.Length; i++)
            {
                if (!S.Contains(i))
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
                return index;
            
            for (int i = 1; i < D.Length; i++)
            {
                if(D[i] < D[index] && !S.Contains(i))
                {
                    index = i;
                }
            }

            return index;
        }
    }

    /*class NodePath
    {

        public NodePath(int cost, Node origin, Node target)
        {
            Cost = cost;
            Target = target;
            Origin = origin;
        }

        public int Cost
        {
            get;
            set;
        }
        public Node Target
        {
            get;
            set;
        }
        public Node Origin {
            get;
            set;
        }
        public bool IsDone
        {
            get;
            set;
        }
    }

    class Node
    {

        public Node(String id)
        {
            ID = id;
            AdjacentNodes = new LinkedList<NodePath>();
        }
        public String ID
        {
            get;
            set;
        }

        public LinkedList<NodePath> AdjacentNodes
        {
            get;
            private set;
        }

        public void AddNodePath(NodePath nodePathToInsert)
        {
            int index = 0;

            if (AdjacentNodes.Count > 0)
            {
                foreach (NodePath tempPath in AdjacentNodes)
                {   
                    if (nodePathToInsert.Cost <= tempPath.Cost)
                    {
                        AdjacentNodes.AddBefore(AdjacentNodes.Find(tempPath), nodePathToInsert);
                        return;
                    }
                    else if (index + 1 == AdjacentNodes.Count)
                    {
                        AdjacentNodes.AddLast(nodePathToInsert);
                        return;
                    }
                    index++;
                }
            }
            else
            {
                AdjacentNodes.AddFirst(nodePathToInsert);
            }
        }
    }*/
}
