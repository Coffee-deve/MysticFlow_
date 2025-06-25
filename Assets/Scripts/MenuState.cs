using System;
using UnityEngine;

    public class MenuState : GameState
    {
    public override void Enter(SceneController controller)
    {
        controller.LoadScene("SampleScene");
        controller.ChangeState(new DuringGameState());
       
    }

    public override void Exit(SceneController controller)
    {
        Application.Quit();
    }

    public override void KeyboardInput(SceneController controller)
    { 

    }
}

