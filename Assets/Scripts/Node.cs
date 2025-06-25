using System;
using System.Collections.Generic;

public class Node
{
    public string Name { get; set; }
    public NodeState State { get; set; }
    public Dictionary<Node, int> Neighbors { get; set; }

    public Node(string name)
    {
        Name = name;
        State = NodeState.Unknown;
        Neighbors = new Dictionary<Node, int>();
    }
}

