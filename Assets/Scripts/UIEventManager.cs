using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIEventManager : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = AudioManager.Instance.SoundEffectSources[0];
    }

    private void ChangeScene(string sceneName)
    {
        bool isSoundEffectOn = PlayerPrefs.GetInt("SoundEffectIsOn", 1) == 1 ? true : false;
        if(isSoundEffectOn)
        {
            audioSource.Play();
        }
        
        StartCoroutine(WaitAndLoadScene(sceneName));
    }

    private IEnumerator WaitAndLoadScene(string sceneName)
    {
        yield return new WaitForSeconds(audioSource.clip.length);
        SceneManager.LoadScene(sceneName);
    }

    public void OnPlayButtonClicked()
    {
        ChangeScene("GameScene");
    }

    public void OnSettingsButtonClicked()
    {
        ChangeScene("SettingsScene");
    }

    public void OnStoreButtonClicked()
    {
        ChangeScene("StoreScene");
    }

    public void BacktoMenuClicked()
    {
        ChangeScene("StartScene");
    }

    public void ReplayButtonClicked()
    {
        // retrive the current scene
        Scene currentScene = SceneManager.GetActiveScene();

        // reload the scene
        audioSource = AudioManager.Instance.SoundEffectSources[0];
        ChangeScene(currentScene.name);
    }
}
