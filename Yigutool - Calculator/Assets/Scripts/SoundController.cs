using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider1;
    public AudioSource[] FX;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("SSettingFX"))
        {
            PlayerPrefs.SetInt("SSettingFX", 1);
            Load1();
        }
        else
        {
            Load1();
        }
    }

    public void ChangeVolume1()
    {
        for (int i=0; i<FX.Length; i++)
        {
            FX[i].volume = volumeSlider1.value;
        }
        Save1();
    }

    private void Load1()
    {
        volumeSlider1.value = PlayerPrefs.GetFloat("SSettingFX");
    }

    private void Save1()
    {
        PlayerPrefs.SetFloat("SSettingFX", volumeSlider1.value);
    }
}
