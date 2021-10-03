using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphComponent : MonoBehaviour
{

    public Graph graph;
    

    // Start is called before the first frame update
    void Start()
    {
        graph = new Graph();
    }

    public void AddNode(Node node)
    {
        graph.Nodes.Add(node);
    }

    public void printNodes()
    {
        foreach (Node node in graph.Nodes)
        {
            Debug.Log(node.transform);
        }
    }

    public void printEdges()
    {
        foreach (Edge edge in graph.Edges)
        {
            Debug.Log("From " + edge.From + " To " + edge.To);
        }
    }

    public Node FindNode(Node node)
    {
        return graph.Nodes.Find(n => n == node);
        
    }

    public void RemoveNode(Node node)
    {
        graph.Nodes.Remove(node);
    }

    public int FindIndex(Node node)
    {
        return graph.Nodes.FindIndex(n => n == node);
    }

    public void AddEdge(Node from, Node to)
    {
        if (FindEdge(from, to).Count == 0)
        {
            graph.Edges.Add(new Edge() { From = from, To = to });
        }
    }

    public List<Edge> FindEdge(Node from, Node to)
    {
        return graph.Edges.FindAll(edge => (edge.From == from && edge.To == to) || (edge.From == to && edge.To == from));
    }

    public void RemoveEdge(Node from, Node to)
    {
        List<Edge> edges = FindEdge(from, to);
        foreach (Edge edge in edges)
        {
            graph.Edges.Remove(edge);
        }
    }

    public void CalculateWeights()
    {
        // graph.DFS();
        graph.BFS1();
    }
    

    // Update is called once per frame
    void Update()
    {
        CalculateWeights();
    }
}
