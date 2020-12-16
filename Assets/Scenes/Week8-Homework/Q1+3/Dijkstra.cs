using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dijekstra
{

    //A Dijkstra building algorithm, returns a Dictionary of paths
    private static Dictionary<NodeType, NodeType> DijekstraBuilder<NodeType>(IWGraph<NodeType> graph, NodeType source)
    {
        //Current weights for each visited node
        Dictionary<NodeType, int> graphCurrW = new Dictionary<NodeType, int>();
        //"Fathers" of each nodes, needed to find the path back
        Dictionary<NodeType, NodeType> Fathers = new Dictionary<NodeType, NodeType>();
        //Marking nodes that are done 
        Dictionary<NodeType, bool> visted = new Dictionary<NodeType, bool>();
        //List of Nodes needed to visit. A sorted list from minimum weight to maximum weight.
        List<NodeType> Mins = new List<NodeType>();
        // Adding the source node 
        Mins.Add(source);
        // Setting first node weight to 0
        graphCurrW.Add(source, 0);
        // Running while we have any node to work on
        while (Mins.Count != 0)
        {
            //Taking the minimum weighted node from the list
            NodeType currNode = Mins[0];
            //Making sure that this node is not yet worked on
            if (!visted.ContainsKey(currNode))
            {
                //Adding this node to visited nodes, which means we don't need to work on it anymore
                visted.Add(currNode, true);
                //Removing it from the list of nodes
                Mins.RemoveAt(0);
                foreach (var neighbor in graph.Neighbors(currNode))
                {
                    //Checking if we have "worked" on the node previously 
                    if (graphCurrW.ContainsKey(neighbor))
                    {
                        //Checking if the current weight is higher then new weight                    
                        if (graphCurrW[neighbor] > graphCurrW[currNode] + graph.Weight(neighbor))
                        {
                            //Set new weight
                            graphCurrW[neighbor] = graphCurrW[currNode] + graph.Weight(neighbor);
                            //Set the new father of the node
                            Fathers[neighbor] = currNode;
                            //if the neighbor is not yet worked on then add it the nodes that need to be worked on
                            if (!visted.ContainsKey(neighbor))
                            {
                                //add the node in a position to keep the list sorted
                                Mins.Insert(getPosInArray(Mins, graphCurrW[neighbor], graph), neighbor);
                            }

                        }
                    }
                    else
                    {
                        //if its a new node completely set weights and father
                        graphCurrW[neighbor] = graphCurrW[currNode] + graph.Weight(neighbor);
                        Fathers[neighbor] = currNode;
                        if (!visted.ContainsKey(neighbor))
                        {
                            Mins.Insert(getPosInArray(Mins, graphCurrW[neighbor], graph), neighbor);
                        }
                    }
                }
            }
            else
            {
                //remove nodes that we don't need to work on
                Mins.RemoveAt(0);
            }
        }
        return Fathers;
    }


    public static List<NodeType> GetPath<NodeType>(IWGraph<NodeType> graph, NodeType source, NodeType dest)
    {
        List<NodeType> path = new List<NodeType>();
        Dictionary<NodeType, NodeType> route = DijekstraBuilder(graph, source);
        //Checking the destination node exists in the possible paths
        if (route.ContainsKey(dest))
        {
            NodeType tempD = dest;
            path.Insert(0, tempD); 
            //creating the list for the path
            while (!path[0].Equals(source))
            {
                tempD = route[tempD];
                path.Insert(0, tempD);
            }
        }
        return path;
    }

    //A binary search insert algorithm, with a given list and a weight returns the position the node needed to be inserted
    //to keep the list sorted
    private static int getPosInArray<NodeType>(List<NodeType> Mins, int destNodeW, IWGraph<NodeType> graph)
    {
        int minIndex = 0;
        int maxIndex = Mins.Count - 1;
        int middle = minIndex + (maxIndex - minIndex) / 2;

        while (minIndex <= maxIndex)
        {
            if (graph.Weight(Mins[middle]) == destNodeW)
            {
                return middle;
            }
            if (destNodeW > graph.Weight(Mins[middle]))
            {
                minIndex = middle + 1;
            }
            if (destNodeW < graph.Weight(Mins[middle]))
            {
                maxIndex = middle - 1;
            }
            middle = minIndex + (maxIndex - minIndex) / 2;
        }
        return middle;
    }
}

