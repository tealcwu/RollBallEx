using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource BackgroundMusicSource;
    public AudioSource[] SoundEffectSources;

    private void Start()
    {
        loadData();
    }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SwitchBackgroundMusic(bool isOn)
    {
        BackgroundMusicSource.gameObject.SetActive(isOn);
    }

    private void loadData()
    {
        bool isBackgroundMusOn = PlayerPrefs.GetInt("BackgroundMusicIsOn",1)==1?true:false;
        SwitchBackgroundMusic(isBackgroundMusOn);

        bool isSoundEffectOn = PlayerPrefs.GetInt("SoundEffectIsOn",1) == 1 ? true : false;
        //SwitchSoundEffects(isSoundEffectOn);

        // load volume
        BackgroundMusicSource.volume = PlayerPrefs.GetFloat("BackgroundMusicVolume",1);

        foreach(AudioSource source in SoundEffectSources)
        {
            source.volume = PlayerPrefs.GetFloat("SoundEffectVolume", 1);
            
        }
    }
}