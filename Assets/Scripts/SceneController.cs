using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance; // singleton for SceneController
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else
            Destroy(gameObject);
            
    }
    public void NextLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1); //asynchronously loads the next scene in game's Build Settings list.
    } 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName); // loads a specific scene by name, asynchronously, using Unity’s SceneManager
    }
}
