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
        if (mass == 0)
        {
            mass = GetComponent<Rigidbody2D>().mass;
        }
        if (rigidity == 0)
        {
            rigidity = mass * 2.5f;
        }
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
        if (graph.FindIndex(this) > -1)
        {
            current_stress = graph.graph.Forces[graph.FindIndex(this)];
        } else
        {
            current_stress = 0;
        }
        if (current_stress > rigidity)
        {
            Debug.Log(this + " Break");
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        } else
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }

        if (GamestateScript.inGame && current_stress > rigidity)
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
