// Definition for a Node.
public class Node
{
    public int val;
    public IList<Node> neighbors;

    public Node()
    {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val)
    {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors)
    {
        val = _val;
        neighbors = _neighbors;
    }
}

public class GraphSolution
{
    public static Node? CloneGraph(Node node)
    {
        if (node is null)
        {
            return null;
        }
        Queue<Node> nodesToVisit = new();
        Dictionary<int, Node> dictNode = new();
        Node initialNode = new(node.val);

        dictNode[node.val] = initialNode;
        nodesToVisit.Enqueue(node);

        while (nodesToVisit.Count > 0)
        {
            Node currentNode = nodesToVisit.Dequeue();
            Node replacementNode = dictNode[currentNode.val];
            foreach (Node nodes in currentNode.neighbors)
            {
                if (!dictNode.ContainsKey(nodes.val))
                {
                    Node inter = new(nodes.val);
                    dictNode[nodes.val] = inter;
                    nodesToVisit.Enqueue(nodes);
                }
                if (!replacementNode.neighbors.Contains(dictNode[nodes.val]))
                {
                    replacementNode.neighbors.Add(dictNode[nodes.val]);
                }
            }
        }
        return initialNode;
    }
}
