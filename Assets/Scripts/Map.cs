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
    public void SolveAlgorithm()
    {
        if (Nodes.Count == 0)
        {
            Console.WriteLine("The map has no nodes.");
            return;
        }

        Node start = Nodes[0]; // First node as a start
        Node goal = Nodes.Last(); // Last node G is goal
        if (goal == null)
        {
            Console.WriteLine("Goal node 'G' not found.");
            return;
        }
        Console.WriteLine("Running Dijkstra algorithm");

        var distances = new Dictionary<Node, int>();
        var previous = new Dictionary<Node, Node>(); // To track path
        var queue = new List<Node>();

        foreach (var node in Nodes)
        {
            distances[node] = int.MaxValue;
            previous[node] = null;
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
                    previous[neighbor.Key] = current; // Track path
                    neighbor.Key.State = NodeState.KnownButNotFastest;
                }
            }
        }

        PrintResults(distances, previous, start, goal);
    }

    private void PrintResults(Dictionary<Node, int> distances, Dictionary<Node, Node> previous, Node start, Node goal)
    {
        Console.WriteLine("\nShortest distances from start:");
        foreach (var pair in distances)
        {
            Console.WriteLine($"{pair.Key.Name}: {pair.Value}");
        }

        Console.WriteLine("\nShortest path from start to goal:");
        var path = new List<Node>();
        for (Node at = goal; at != null; at = previous[at])
        {
            path.Insert(0, at);
        }

        if (path[0] != start)
        {
            Console.WriteLine("No path found.");
        }
        else
        {
            Console.WriteLine(string.Join(" -> ", path.Select(n => n.Name)));
            Console.WriteLine($"Total cost: {distances[goal]}");
        }
    }

}

