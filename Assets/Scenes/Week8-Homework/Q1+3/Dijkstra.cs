using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dijekstra
{
    private static Dictionary<NodeType, NodeType> DijekstraBuilder<NodeType>(IWGraph<NodeType> graph, NodeType source)
    {
        Dictionary<NodeType, int> graphCurrW = new Dictionary<NodeType, int>();
        Dictionary<NodeType, NodeType> Fathers = new Dictionary<NodeType, NodeType>();
        Dictionary<NodeType, bool> visted = new Dictionary<NodeType, bool>();

        List<NodeType> Mins = new List<NodeType>();
        Mins.Add(source);
        graphCurrW.Add(source, 0);
        while (Mins.Count != 0)
        {
            NodeType currNode = Mins[0];
            if (!visted.ContainsKey(currNode))
            {
                visted.Add(currNode, true);
                Mins.RemoveAt(0);
                foreach (var neighbor in graph.Neighbors(currNode))
                {
                    if (graphCurrW.ContainsKey(neighbor))
                    {
                       // Debug.Log("27");
                        if (graphCurrW[neighbor] > graphCurrW[currNode] + graph.Weight(neighbor))
                        {
                         //   Debug.Log("30");
                            graphCurrW[neighbor] = graphCurrW[currNode] + graph.Weight(neighbor);
                           // Debug.Log("32");
                            Fathers[neighbor] = currNode;
                            if (!visted.ContainsKey(neighbor))
                            {
                              //  Debug.Log("36");
                                Mins.Insert(getPosInArray(Mins, graphCurrW[neighbor], graph), neighbor);
                            }

                        }
                    }
                    else
                    {
                     //  Debug.Log("44");
                        graphCurrW[neighbor] = graphCurrW[currNode] + graph.Weight(neighbor);
                       // Debug.Log("46");
                        Fathers[neighbor] = currNode;
                        if (!visted.ContainsKey(neighbor))
                        {
                         //   Debug.Log("50");
                            Mins.Insert(getPosInArray(Mins, graphCurrW[neighbor], graph), neighbor);
                        }
                    }
                }
            }
            else
            {
                Mins.RemoveAt(0);
            }
        }
        return Fathers;
    }


    public static List<NodeType> GetPath<NodeType>(IWGraph<NodeType> graph, NodeType source, NodeType dest)
    {
        List<NodeType> path = new List<NodeType>();
        Dictionary<NodeType, NodeType> route = DijekstraBuilder(graph, source);
        if (route.ContainsKey(dest))
        {
            NodeType tempD = dest;
            path.Insert(0, tempD); //

            while (!path[0].Equals(source))
            {
                //Debug.Log("END?");
                tempD = route[tempD];
                path.Insert(0, tempD);
            }
           // Debug.Log("return");
        }
        return path;
    }


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

