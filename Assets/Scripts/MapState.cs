using System;
using UnityEngine;
public class MapState : GameState
    {
    public override void Enter(SceneController controller)
    {
        controller.LoadScene("Map_2");
        controller.ChangeState(new MapState2());
    }

    public override void Exit(SceneController controller)
    {
        controller.LoadScene("SampleScene");
        controller.ChangeState(new DuringGameState());
        
    }

    public override void GoToInventory(SceneController controller)
    {
        controller.LoadScene("Inventory");
        controller.ChangeState(new InventoryState());
        
    }

}

