#if UNITY_EDITOR  // to make game exit using escape during testing
using UnityEditor;// to make game exit using escape during testing
#endif// to make game exit using escape during testing

using UnityEngine;
using UnityEngine.InputSystem;


public class EnterKeySceneLoader : MonoBehaviour
{
    void QuitGame()// to make game exit using escape during testing
    {                   // to make game exit using escape during testing
        Application.Quit();// to make game exit using escape during testing
#if UNITY_EDITOR// to make game exit using escape during testing
        EditorApplication.isPlaying = false;  // to make game exit using escape during testing
#endif// to make game exit using escape during testing
    }
    void Update()
    {

        if (Keyboard.current.enterKey.wasPressedThisFrame)
        {
            SceneController.instance.NextLevel();
        }
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            QuitGame(); // to make game exit using escape during testing
            Application.Quit();
        }
    }
}
