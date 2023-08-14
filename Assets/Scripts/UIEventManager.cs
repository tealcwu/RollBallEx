using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIEventManager : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void PlaySound()
    {
        audioSource.Play();
    }

    private void ChangeScene(string sceneName)
    {
        PlaySound();
        StartCoroutine(WaitAndLoadScene(sceneName));
    }

    private IEnumerator WaitAndLoadScene(string sceneName)
    {
        yield return new WaitForSeconds(audioSource.clip.length);
        SceneManager.LoadScene(sceneName);
    }

    public void OnPlayButtonClicked()
    {
        PlaySound();
        SceneManager.LoadScene("GameScene");

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
        ChangeScene(currentScene.name);
    }
}
