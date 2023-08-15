using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    public Slider backgroundMusicSlider;
    public Toggle backgroundMusicToggle;
    public Slider soundEffectsSlider;
    public Toggle soundEffectsToggle;

    private AudioSource BackgroundMusicAudioSource;
    private AudioSource[] SoundEffectAudioSources;

    // Start is called before the first frame update
    void Start()
    {
        // init audio sources
        BackgroundMusicAudioSource = AudioManager.Instance.BackgroundMusicSource;
        SoundEffectAudioSources = AudioManager.Instance.SoundEffectSources;

        // init background music
        backgroundMusicSlider.value = BackgroundMusicAudioSource.volume;
        soundEffectsSlider.value = SoundEffectAudioSources[0].volume;

        // init sound effects
        bool isBackgroundMusOn = PlayerPrefs.GetInt("BackgroundMusicIsOn", 1) == 1 ? true : false;
        backgroundMusicToggle.isOn = isBackgroundMusOn;

        bool isSoundEffectOn = PlayerPrefs.GetInt("SoundEffectIsOn", 1) == 1 ? true : false;
        soundEffectsToggle.isOn = isSoundEffectOn;
    }

    // Update is called once per frame
    public void OnBackgroundMusicVolumeChanged()
    {
        AudioManager.Instance.BackgroundMusicSource.volume = backgroundMusicSlider.value;

        // save to PlayerPrefs
        PlayerPrefs.SetFloat("BackgroundMusicVolume", backgroundMusicSlider.value);
    }

    public void OnBackgroundMusciToggleChanged()
    {
        int isOn = backgroundMusicToggle.isOn ? 1 : 0;
        PlayerPrefs.SetInt("BackgroundMusicIsOn", isOn);

        // update backgound music audio source status
        AudioManager.Instance.SwitchBackgroundMusic(backgroundMusicToggle.isOn);
    }

    public void OnSoundEffectVolumeChanged()
    {
        foreach(AudioSource soundeffectSource in  SoundEffectAudioSources)
        {
            soundeffectSource.volume = soundEffectsSlider.value;
        }

        // save to PlayerPrefs
        PlayerPrefs.SetFloat("SoundEffectVolume", soundEffectsSlider.value);
    }

    public void OnSoundEffectToggleChanged()
    {
        int isOn = soundEffectsToggle.isOn ? 1 : 0;
        PlayerPrefs.SetInt("SoundEffectIsOn", isOn);
    }
}