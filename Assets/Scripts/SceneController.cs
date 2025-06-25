using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    //public static SceneController instance; // singleton for SceneController
    GameState currentState; // holds a reference to the active state
    public static SceneController instance;
   public MenuState menuState = new MenuState();
   public DuringGameState gameState = new DuringGameState();
   public MapState mapState = new MapState();
   public  InventoryState inventoryState = new InventoryState();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void ChangeState(GameState newState)
    {
        currentState = newState;
    }

    void Start()
    {
        currentState = menuState;

    }

    void Update()
    {

        if (Keyboard.current.enterKey.wasPressedThisFrame)
        {
            currentState.Enter(this);
        }
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            currentState.Exit(this);
        }
        if(Keyboard.current.iKey.wasPressedThisFrame)
        {
            currentState.KeyboardInput(this);
        }
    }
}
