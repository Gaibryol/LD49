using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{

    public float mass;
    public float rigidity;
    public float current_stress;
    public List<Node> adj;
    public List<Node> parent;
    private GraphComponent graph;
    private bool first;
    // Start is called before the first frame update
    void Start()
    {
        mass = GetComponent<Rigidbody2D>().mass;
        rigidity = mass * 2.5f;
        adj = new List<Node>();
        first = true;
        graph = GameObject.FindGameObjectWithTag("Graph").GetComponent<GraphComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (first)
        {
            graph.AddNode(this);
            first = !first;
        }

        if (graph.FindIndex(this) > -1 && graph.graph.Forces[graph.FindIndex(this)] > rigidity)
        {
            Debug.Log(this + " Break");
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        } else
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }

        if (GamestateScript.inGame && graph.graph.Forces[graph.FindIndex(this)] > rigidity)
        {
            graph.RemoveNode(this);
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log(graph.FindNode(collision.gameObject.GetComponent<Node>()));
        if (collision.gameObject.transform.position.y <= collision.otherCollider.transform.position.y)
        {
            Node node = collision.gameObject.GetComponent<Node>();

            if (node != null && !adj.Contains(node))
            {
                adj.Add(node);
            }
            graph.AddEdge(collision.otherCollider.GetComponent<Node>(), node);
        }
        if (collision.gameObject.transform.position.y > collision.otherCollider.transform.position.y)
        {
            Node node = collision.gameObject.GetComponent<Node>();

            if (node!=null && !parent.Contains(node))
            {
                parent.Add(node);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        adj.RemoveAll(node => node == collision.gameObject.GetComponent<Node>());
        parent.RemoveAll(node => node == collision.gameObject.GetComponent<Node>());
        graph.RemoveEdge(collision.gameObject.GetComponent<Node>(), collision.otherCollider.GetComponent<Node>());
    }
}
