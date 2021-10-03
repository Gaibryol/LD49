using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Graph
{

    public Graph()
    {
        Nodes = new List<Node>();
        Edges = new List<Edge>();
        Forces = new float[99];
    }

    public List<Node> Nodes { get; private set; }
    public List<Edge> Edges { get; private set; }
    public float[] Forces;

    public void DFS()
    {
        //Node root = Nodes.Find(node => node.gameObject.tag == "Ground");
        bool[] visited = new bool[Nodes.Count];

        //Debug.Log(DFSUtil(root, visited, weights));
        //for (int i = 0; i < Nodes.Count; i++)
        //{
        //    Debug.Log(Nodes[i] + " " + weights[i]);
        //}

        float[] weights = new float[Nodes.Count];
        List<Node> nodes = Nodes.FindAll(node => (node.parent.Count == 0));
        for (int i = 0; i < nodes.Count; i++)
        {
            int index = Nodes.FindIndex(node => node == nodes[i]);
            DFSUtil1(index, new bool[Nodes.Count], weights);
            Debug.Log("*************");
            for (int j = 0; j < Nodes.Count; j++)
            {
                Debug.Log(Nodes[j] + " " + weights[j]);
            }
            Debug.Log("*************");
        }
        
    }

    public void BFS1()
    {
        // float[,] total_weights = new float[Nodes.Count, Nodes.Count];
        List<float[]> total_weights = new List<float[]>();
        for (int i = 0; i < Nodes.Count; i++)
        {
            float[] weights = new float[Nodes.Count];
            //Node current = Nodes[i];
            //float weight = current.mass;
            //float scale = current.adj.Count;
            //Debug.Log(Nodes[i]);
            LinkedList<int> queue = new LinkedList<int>();
            queue.AddLast(i);
            float weight = Nodes[i].mass;
            //foreach (Node node in current.adj)
            //{
            //    queue.AddLast(Nodes.FindIndex(n => n == node));
            //}

            while (queue.Any())
            {
                int idx = queue.First();
                queue.RemoveFirst();
                Node current = Nodes[idx];
                if (idx == i)
                {
                    weight = Nodes[i].mass;
                } else
                {
                    weight = weights[idx];

                }
                float scale = current.adj.Count;



                foreach (Node node in current.adj)
                {
                    
                    int c = Nodes.FindIndex(n => n == node);
                    weights[c] += (weight) / scale;
                    queue.AddLast(c);
                    //Debug.Log(Nodes[i] + " Contribution To " + Nodes[c] + " Weight: " + weight + " Scale: " + scale);
                }
            }
            total_weights.Add(weights);
        }
        //StringBuilder sb = new StringBuilder();
        //for (int i = 0; i < Nodes.Count; i++)
        //{
        //    sb.Append(Nodes[i].name.Replace(" ", ""));
        //    sb.Append(' ');
        //}
        //sb.AppendLine();
        float[] sum = new float[Nodes.Count];
        for (int i = 0; i < total_weights.Count; i++)
        {
            for (int j = 0; j < total_weights[i].GetLength(0); j++)
            {
                //sb.Append(total_weights[i][j]);
                //sb.Append(' ');
                sum[j] += total_weights[i][j];
            }
            //sb.AppendLine();
        }
        //Debug.Log(sb.ToString());
        Forces = sum;
    }

    public void BFS()
    {
        //List<Node> nodes = Nodes.FindAll(node => (node.parent.Count == 0));
        List<Node> nodes = Nodes;
        for (int i = 0; i < nodes.Count; i++)
        {
            float[] weights = new float[Nodes.Count];
            bool[] visited = new bool[Nodes.Count];
            int j = Nodes.FindIndex(n => n == nodes[i]);
            LinkedList<int> queue = new LinkedList<int>();
            queue.AddLast(j);
            while (queue.Any())
            {
                int s = queue.First();
                Node s_node = Nodes[s];
                float scale = s_node.adj.Count;
                Debug.Log(Nodes[s]);
                queue.RemoveFirst();

                List<Node> list = Nodes[s].adj;
                foreach (Node node in list)
                {
                    int index = Nodes.FindIndex(n => n == node);
                    if (!visited[index])
                    {
                        weights[index] += (s_node.mass + weights[s]) / scale;

                        Debug.Log(s_node + " mass: " + s_node.mass + "  Force: " + weights[s] + " Links: " + scale + " \\ Added Force: " + (s_node.mass + weights[s]) / scale + " Total Force Exerted on " + Nodes[index] + " "  + weights[index]);
                        visited[index] = true;
                        queue.AddLast(index);
                    }
                }
            }
            for (int p = 0; p < Nodes.Count; p++)
            {
                Debug.Log(Nodes[p] + " " + weights[p]);
            }
            Debug.Log("************");
        }
        //for (int p = 0; p < Nodes.Count; p++)
        //{
        //    Debug.Log(Nodes[p] + " " + weights[p]);
        //}

    }

    private void DFSUtil1(int index, bool[] visited, float[] weights)
    {
        
        visited[index] = true;
        Debug.Log("Visited " + Nodes[index]);

        List<Node> adj = Nodes[index].adj;
        float scale = adj.Count;
        foreach (Node n in adj)
        {
            int j = Nodes.FindIndex(nn => nn == n);
            if (Nodes[j].tag == "Ground")
            {
                continue;
            }
            if (!visited[j])
            {
                bool[] visited_clone = new bool[visited.Length];
                visited.CopyTo(visited_clone, 0);
                
                weights[j] += (Nodes[index].mass + weights[index])/scale;
                DFSUtil1(j, visited_clone, weights);
            }
        }
        //return Nodes[index].mass / scale + weights[index];
    }

    private float DFSUtil(Node node, bool[] visited, float[] weights)
    {
        int i = Nodes.FindIndex(n => n == node);
        visited[i] = true;
        Debug.Log("Visited " + Nodes[i]);

        List<Node> adj = node.adj;
        foreach(Node n in adj)
        {
            int j = Nodes.FindIndex(nn => nn == n);
            if (!visited[j])
            {
                bool[] visited_clone = new bool[visited.Length];
                visited.CopyTo(visited_clone, 0);
                weights[i] += DFSUtil(Nodes[j], visited_clone, weights);
            }
        }
        return node.mass + weights[i];
    }
}

//public class Node
//{
//    public NodeType Value { get; set; }
//    public float mass;
//    public float rigidity;
//    public List<Node<NodeType>> adj;

//    public Node()
//    {
//        adj = new List<Node<NodeType>>();
//    }
//}

public class Edge
{
    //public EdgeType Value { get; set; }

    public Node From { get; set; }
    public Node To { get; set; }
}
