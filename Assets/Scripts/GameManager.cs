using UnityEngine;
using UnityEngine.InputSystem;

#if UNITY_EDITOR  // to make game exit using escape during testing
using UnityEditor;
#endif

// only works in testing when we start from menu scene
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private void Awake()
    {
        // If an instance already exists, destroy this duplicate
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Otherwise, set this as the one true instance
        Instance = this;

        // Make sure this GameObject isn't destroyed when changing scenes
        DontDestroyOnLoad(gameObject);
    }
    void QuitGame()// to make game exit using escape during testing
    {                   
        Application.Quit();
        #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
        #endif
    }

    void Update()
    {
        if (Keyboard.current.xKey.wasPressedThisFrame)
        {
            QuitGame(); // to make game exit using escape during testing
            Application.Quit();
        }
    }
}
