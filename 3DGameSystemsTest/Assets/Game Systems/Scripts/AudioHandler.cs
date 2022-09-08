using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioHandler : MonoBehaviour
{
    public AudioMixer masterAudio;
    private string _slider;

    public void SelectSlider(string slider)
    {
        _slider = slider;
    }
    public void ChangeVolume(float volume)
    {
        masterAudio.SetFloat(_slider, volume);
    }
}
