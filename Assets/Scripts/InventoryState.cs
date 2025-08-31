using System;
using UnityEngine;


public class InventoryState : GameState
    {
    public override void Enter(SceneController controller)
    {
        
    }

    public override void Exit(SceneController controller)
    {
        controller.LoadScene("SampleScene");
        controller.ChangeState(new DuringGameState());
       
    }

    public override void KeyboardInput(SceneController controller)
    {

    }
}
