using System;
using System.Collections;
using Microsoft.EntityFrameworkCore.Internal;

namespace Graph{
    class Program{
        static void Main(string[] args){
            /** 
            *  Graph:
            *  A graph is a non-linear data structure consisting of nodes and
            *  edges. The nodes are referred as vertices and edges are lines that 
            *  that connect any two nodes in the graph. The graph that was 
            *  implemented is this program could either be directed/undirected
            *  or weighted/unweighted depending on how you create it in the 
            *  main.
            *  
            *                    Graph:
            *                 [0]-------[1]\
            *                  |      /  |   \
            *         Edge-->  |    /    |    [2] <-- Vertex
            *                  |  /      |   /
            *                 [4]-------[3]/  
            *                 
            *  Types of Graphs:
            *  - Directed(-->) vs Undirected(---)
            *  - Weighted(-$-) vs Unweighted(---)
            *                 
            *  Graph Methods:
            *  - AddEdge(int source, int destination, int ccost): Adds an edge between
            *    two specific vertices.
            *  - RemoveEdge(int source, destination): Removes an edge between to vertices.
            *  - Adjacent(int testV, int adjV): If the two vertices are adjacent, it 
            *    returns true.
            *  - Neighbors(int textV): This method returns an array of all the adject vertices 
            *    which are connected to the parameter vertex.
            *  - Display(): This method prints all the vertices within the graph.
            *  - Prim'sAlgorithm(int startV): This methods finds a minimum spanning tree
            *    for a weighted underiected graph.
            *  - Dijkstra'sAlgorithm(int startV): This method finds the shortest path for
            *    each vertex from a given vertex.
            *  - BreadthFirstSearch(int startV): This method prints out the breadth first 
            *    traversal of the graph from a given vertex.
            *  - DepthFirstSearch(int startV): This method prints out the depth first traversal
            *    of the graph from a given vertex.
            *  - IsCyclic(): If there is a cycle in the graph, it returns true.
            *  - TotalCost(): This method returns the total cost from a graph.
            *  - Print(): This method is another dsiplay method, but it shows the weights.             
            */
        }
    }
}
