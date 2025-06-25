using UnityEngine;

public abstract class GameState
{
    protected SceneController controller;

    public abstract void Enter(SceneController controller);
    public abstract void Exit(SceneController controller);
    public abstract void KeyboardInput(SceneController controller);

}
