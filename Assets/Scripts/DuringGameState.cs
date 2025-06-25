using System;
using UnityEngine;


public class DuringGameState : GameState
    {
    public override void Enter(SceneController controller)
    {
        controller.LoadScene("Map");
        controller.ChangeState(new MapState());
        
    }

    public override void Exit(SceneController controller)
    {
        controller.LoadScene("Menu");
        controller.ChangeState(new MenuState());
        
    }

    public override void KeyboardInput(SceneController controller)
    {
        controller.LoadScene("Inventory");
        controller.ChangeState(new InventoryState());
        

    }

}

