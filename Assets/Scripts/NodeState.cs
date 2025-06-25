using System;

public class NodeState
{
    public string StateName { get; private set; }

    private NodeState(string stateName)
    {
        StateName = stateName;
    }

    public static readonly NodeState Unknown = new NodeState("Unknown");
    public static readonly NodeState KnownButNotFastest = new NodeState("Known but not fastest");
    public static readonly NodeState Fastest = new NodeState("Fastest");
}

