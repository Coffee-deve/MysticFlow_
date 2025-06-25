using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Map
{
    private static Map instance;
    public List<Node> Nodes { get; private set; }

    private Map()
    {
        Nodes = new List<Node>();
    }

    public void AddNode(Node node)
    {
        Nodes.Add(node);
    }
    public static Map GetInstance()
    {
        if (instance == null)
        {
            instance = new Map();
        }
        return instance;
    }

    public void SolveAlgorithm(string startNodeName)
    {
        var startNode = Nodes.FirstOrDefault(n => n.Name == startNodeName);
        if (startNode != null)
        {
            SolveAlgorithm(startNode);
        }
        else
        {
            Console.WriteLine($"Start node '{startNodeName}' not found.");
        }
    }

    public void SolveAlgorithm(Node start)
    {
        Console.WriteLine("Running Dijkstra algorithm...");
        var distances = new Dictionary<Node, int>();
        var queue = new List<Node>();

        foreach (var node in Nodes)
        {
            distances[node] = int.MaxValue;
            node.State = NodeState.Unknown;
            queue.Add(node);
        }

        distances[start] = 0;

        while (queue.Count > 0)
        {
            var current = queue.OrderBy(n => distances[n]).First();
            queue.Remove(current);

            current.State = NodeState.Fastest; // finalized

            foreach (var neighbor in current.Neighbors)
            {
                int alt = distances[current] + neighbor.Value;
                if (alt < distances[neighbor.Key])
                {
                    distances[neighbor.Key] = alt;
                    neighbor.Key.State = NodeState.KnownButNotFastest;
                }
            }
        }

        PrintResults(distances);
    }

    private void PrintResults(Dictionary<Node, int> distances)
    {
        Console.WriteLine("Shortest distances:");
        foreach (var pair in distances)
        {
            Console.WriteLine($"{pair.Key.Name}: {pair.Value}");
        }
    }

}

