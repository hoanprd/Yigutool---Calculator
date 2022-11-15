using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundControllerMain : MonoBehaviour
{
    public AudioSource[] FX;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < FX.Length; i++)
        {
            FX[i].volume = PlayerPrefs.GetFloat("SSettingFX");
        }
    }
}
