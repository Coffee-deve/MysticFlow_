using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class MapBuilder
{
    public static void BuildSampleMap(Map map)
    {
        var nodeA = new Node("A"); // start node
        var nodeB = new Node("B");
        var nodeC = new Node("C");
        var nodeD = new Node("D");
        var nodeE = new Node("E");
        var nodeF = new Node("F");
        var nodeG = new Node("G");

        nodeA.Neighbors[nodeB] = 5;
        nodeA.Neighbors[nodeC] = 20;

 
        nodeB.Neighbors[nodeD] = 3;
        nodeB.Neighbors[nodeE] = 40;

        nodeC.Neighbors[nodeD] = 3;
        nodeC.Neighbors[nodeF] = 60;

        nodeD.Neighbors[nodeE] = 3;
        nodeD.Neighbors[nodeF] = 3;

        nodeE.Neighbors[nodeG] = 10;

        nodeF.Neighbors[nodeG] = 15;

        map.AddNode(nodeA);
        map.AddNode(nodeB);
        map.AddNode(nodeC);
        map.AddNode(nodeD);
        map.AddNode(nodeE);
        map.AddNode(nodeF);
        map.AddNode(nodeG);
    }
}

