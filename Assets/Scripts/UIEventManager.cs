using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIEventManager : MonoBehaviour
{
    public void OnPlayButtonClicked()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnSettingsButtonClicked()
    {
        SceneManager.LoadScene("SettingsScene");
    }

    public void OnStoreButtonClicked()
    {
        SceneManager.LoadScene("StoreScene");
    }

    public void BacktoMenuClicked()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void ReplayButtonClicked()
    {
        // retrive the current scene
        Scene currentScene = SceneManager.GetActiveScene();

        // reload the scene
        SceneManager.LoadScene(currentScene.name);
    }
}
