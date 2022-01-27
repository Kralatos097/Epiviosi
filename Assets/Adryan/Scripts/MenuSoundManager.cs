using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuSoundManager : MonoBehaviour
{

    public AudioMixer Musics;
    public Slider slider;


    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat("CurrentMusicVol");
    }

    public void SetMusicVol(float sliderValue)
    {
        Musics.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("CurrentMusicVol", slider.value);
    }
}
