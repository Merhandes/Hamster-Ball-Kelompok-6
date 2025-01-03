using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public Slider sliderMusic;
    public AudioSource sumberSuara;
    public float volume = 1;

    public const string keyVolume = "VOLUME";

    private void Start()
    {
        float volumeTerakhir = PlayerPrefs.GetFloat(keyVolume);
        KetikaSliderDiubah(volumeTerakhir);
        sliderMusic.value = volumeTerakhir;
    }

    public void KetikaSliderDiubah(float nilaiSlider)
    {
        volume = nilaiSlider;
        sumberSuara.volume = nilaiSlider;

        PlayerPrefs.SetFloat(keyVolume, nilaiSlider);
    }
}
