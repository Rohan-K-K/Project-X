using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneToLoad;
    [Tooltip("Set this to true if this script is attached to an on-map loading zone")]
    public bool onGridLoader;

    public void LoadNewScene(string sceneName)
    {
        string originalScene = SceneManager.GetActiveScene().name;
        Debug.Log("Loading new scene: " + sceneName);
        SceneManager.LoadScene(sceneName);
        Debug.Log("Scene loaded successfully");
        Debug.Log("Unloading previous scene");
        try
        {
            SceneManager.UnloadSceneAsync(originalScene);
            Debug.Log("Previous scene unloaded successfully");
        }
        catch (Exception e)
        {
            Debug.LogError("Previous scene failed to unload\n" + e);
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }

    public void OnTriggerEnter()
    {
        if (onGridLoader)
        {
            Debug.Log("Loading zone entered");
            LoadNewScene(sceneToLoad);
        }
    }
}
