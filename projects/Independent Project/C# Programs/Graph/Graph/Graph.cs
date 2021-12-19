using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace Graph{
    class Graph{
        // Member variables.
        private int numVertices;
        private List[] adjList;

        // Parameter Constructor.
        public Graph(int numV) {
            numVertices = numV;
            adjList = new List[numV];
            for (int i = 0; i < adjList.Length; i++) {
                adjList[i] = new List();
            }
        }

        public void AddEdge(int s, int d, int c) {
            // Adds edge to the graph.
            adjList[s].Add(s, d, c);
        }

        public void RemoveEdge(int s, int d) {
            // Removes edge from the graph.
            adjList[s].Delete(s, d);
        }

        public bool Adjacent(int testV, int adjV) {
            // Returns whether two vertices are adjacent.
            bool adjFound = false;
            for (int i = 0; i < adjList[testV].Size() && !adjFound; i++) {
                if (adjList[testV].GetIndex(i).GetDestination() == adjV) {
                    adjFound = true;
                }
            }
            return adjFound;
        }

        public int[] Neighbors(int testV) {
            // Gets all the vertices that are neighbors of 
            // a specific vertex.
            int[] neighborArray = new int[adjList[testV].Size()];
            for (int i = 0; i < adjList[testV].Size(); i++) {
                neighborArray[i] = adjList[testV].GetIndex(i).GetDestination();
            }
            return neighborArray;
        }

        public void Display() {
            // Prints the graph.
            for (int indexA = 0; indexA < numVertices; indexA++) {
                Console.Write("Vertes " + indexA + " is connected to ");
                for (int indexL = 0; indexL < adjList[indexA].Size(); indexL++) {
                    if (indexL == (adjList[indexA].Size() - 1)) {
                        Console.WriteLine(adjList[indexA].GetIndex(indexL).GetDestination());
                    }
                    else {
                        Console.Write(adjList[indexA].GetIndex(indexL).GetDestination() + " , ");
                    }
                }
            }
        }

        /**
         *  Prim's Algorithm is a greedy algorithm that finds a minimum spanning tree for
         *  a weighted undirected graph. This means it finds a subset of the edges that 
         *  forms a tree that includes every vertex, where the total weight of all the 
         *  edges in the tree is minimized. The algorithm operates by building this tree
         *  one vertex at a time, from an arbitrary starting vertex, at each step adding 
         *  the cheapest possible connection from the tree to another vertex.
         */
        public void PrimsAlgorithm(int startV) {
            int[,] graph = ConvertToMatrix();
            int[] parent = new int[numVertices];
            int[] key = new int[numVertices];
            bool[] mstSet = new bool[numVertices];
            for (int i = 0; i < numVertices; i++) { 
                key[i] = int.MaxValue;
                mstSet[i] = false;
            }
            key[startV] = 0;
            parent[startV] = -1;
            for (int count = 0; count < numVertices; count++) {
                int u = MinDistance(key, mstSet);
                mstSet[u] = true;
                for (int v = 0; v < numVertices; v++) {
                    if (graph[u, v] != 0 && mstSet[v] == false && graph[u, v] < key[v]) {
                        parent[v] = u;
                        key[v] = graph[u, v];
                    }
                }
            }
            Console.WriteLine("Edge \tWeight");
            for (int j = 1; j < numVertices; j++) {
                Console.WriteLine(parent[j] + " - " + j + "\t" + graph[j, parent[j]]);
            }
        }

        /**
         *  Dijkstra's algorithm (/ˈdaɪkstrəz/ DYKE-strəz) is an algorithm for finding 
         *  the shortest paths between nodes in a graph, which may represent, for 
         *  example, road networks. 
         */
        public void DijkstrasAlgorithm(int startV) {
            int[,] graph = ConvertToMatrix();
            int[] dist = new int[numVertices];
            bool[] sptSet = new bool[numVertices];
            for (int i = 0; i < numVertices; i++) {
                dist[i] = int.MaxValue;
                sptSet[i] = false;
            }
            dist[startV] = 0;
            for (int count = 0; count < (numVertices-1); count++) {
                int u = MinDistance(dist, sptSet);
                sptSet[u] = true;
                for (int v = 0; v < numVertices; v++) {
                    if (!sptSet[v] && graph[u, v] != 0 && dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v]) {
                        dist[v] = dist[u] + graph[u, v];
                    }
                }
            }
            Console.WriteLine("Vertex     Distance from Source");
            for (int j = 0; j < numVertices; j++) {
                Console.Write(j + " \t\t " + dist[j] + "\n");
            }
        }

        public void BreadthFirstSearch(int startV) {
            // Initialize "visited".
            bool[] visited = new bool[numVertices];
            for (int i = 0; i < numVertices; i++) {
                visited[i] = false;
            }
            // Queue list with help us.
            Queue queue = new Queue();
            visited[startV] = true;
            queue.Enqueue(startV);
            // Bread first search algorithm...
            int breadthNumber = 1;
            while (!queue.IsEmpty()) {
                Console.WriteLine("Breadth: " + breadthNumber);
                int numV = queue.Count();
                // Traverses every element in the queue.
                for (int j = 0; j < numV; j++) {
                    int vertexValue = queue.Peek();
                    Console.WriteLine(vertexValue);
                    queue.Dequeue();
                    // Gets all the elements for each queue element.
                    int numAdjV = adjList[vertexValue].Size();
                    for (int k = 0; k < numAdjV; k++) {
                        if (visited[adjList[vertexValue].GetIndex(k).GetDestination()] == false) {
                            visited[adjList[vertexValue].GetIndex(k).GetDestination()] = true;
                            queue.Enqueue(adjList[vertexValue].GetIndex(k).GetDestination());
                        }
                    }
                }
                // Update value.
                breadthNumber++;
            }
        }

        public void DepthFirstSearch(int startV) {
            // Initialize "visited".
            bool[] visited = new bool[numVertices];
            for (int i = 0; i < numVertices; i++) {
                visited[i] = false;
            }
            // Stack list will help us.
            Stack stack = new Stack();
            visited[startV] = true;
            stack.Push(startV);
            // Depth first search algorithm...
            int depthNumber = 1;
            while (!stack.IsEmpty()) {
                Console.WriteLine("Depth: " + depthNumber);
                int numV = stack.Count();
                // Traverses every element in the stack.
                for (int j = 0; j < numV; j++) {
                    int vertexValue = stack.Peek();
                    Console.WriteLine(vertexValue);
                    stack.Pop();
                    // Gets all the elements for each stack element.
                    int numAdjV = adjList[vertexValue].Size();
                    for (int k = 0; k < numAdjV; k++) {
                        if (visited[adjList[vertexValue].GetIndex(k).GetDestination()] == false) {
                            visited[adjList[vertexValue].GetIndex(k).GetDestination()] = true;
                            stack.Push(adjList[vertexValue].GetIndex(k).GetDestination());
                        }
                    }
                }
                // Update value.
                depthNumber++;
            }
        }

        public bool IsCyclic() {
            // These two data structure will help
            // us determine whether graph is cyclic.
            bool[] visited = new bool[numVertices];
            bool[] recStack = new bool[numVertices];
            // Checks all the nodes in the graph.
            for (int i = 0; i < numVertices; i++) {
                if (IsCyclicUtil(i, visited, recStack)) {
                    return true;
                }
            }
            // Default return value.
            return false;
        }

        private bool IsCyclicUtil(int i, bool[] visited, bool[] recStack) {
            // Recursive conditions:
            if (recStack[i]) {
                return true;
            }
            if (visited[i]) {
                return false;
            }
            // Update values.
            visited[i] = true;
            recStack[i] = true;
            // Check all the connected nodes...
            List children = adjList[i];
            for (int c = 0; c < children.Size(); c++) {
                // Recursive call.
                if (IsCyclicUtil(children.GetIndex(c).GetDestination(), visited, recStack)) {
                    return true;
                }
            }
            // Update value.
            recStack[i] = false;
            // Default return value.
            return false;
        }

        private int[,] ConvertToMatrix(){
            // Converts the graph to an integer matrix.
            int[,] graph = new int[numVertices, numVertices];
            for (int col = 0; col < numVertices; col++) {
                for (int row = 0; row < numVertices; row++) {
                    for (int index = 0; index < adjList[col].Size(); index++) {
                        if (col == adjList[col].GetIndex(index).GetSource() && row == adjList[col].GetIndex(index).GetDestination()) {
                            graph[row, col] = adjList[col].GetIndex(index).GetCost();
                        }
                    }
                }
            }
            return graph;
        }

        private int MinDistance(int[] dist, bool[] sptSet){
            // Returns index of minimum distance.
            int min = int.MaxValue;
            int minIndex = -1;
            for (int v = 0; v < numVertices; v++) {
                if (sptSet[v] == false && dist[v] <= min) {
                    min = dist[v];
                    minIndex = v;
                }
            }
            return minIndex;
        }

        public int TotalCost(){
            // Gets the total cost of all the edges.
            int total = 0;
            for (int ver = 0; ver < numVertices; ver++) {
                for (int adj = 0; adj < adjList[ver].Size(); adj++) {
                    total += adjList[ver].GetIndex(adj).GetCost();
                }
            }
            return total;
        }

        public void Print(){
            // Prints the graph in another way.
            for (int v = 0; v < numVertices; v++) {
                for (int e = 0; e < adjList[v].Size(); e++) {
                    Console.WriteLine("Vertex " + adjList[v].GetIndex(e).GetSource()  
                                      + " is connected to " + adjList[v].GetIndex(e).GetDestination() 
                                      + " with weight " + adjList[v].GetIndex(e).GetCost());
                }
            }
        }
    }
}
