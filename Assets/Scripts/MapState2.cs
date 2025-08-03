using System;
using UnityEngine;
public class MapState2 : GameState
{
    public override void Enter(SceneController controller)
    {

        // this will solve Dijkstra Algorithm
    }

    public override void Exit(SceneController controller)
    {
        controller.LoadScene("SampleScene");
        controller.ChangeState(new DuringGameState());

    }

    public override void KeyboardInput(SceneController controller)
    {
        controller.LoadScene("Inventory");
        controller.ChangeState(new InventoryState());

    }

}


