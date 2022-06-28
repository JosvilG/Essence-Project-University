using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Sonido : MonoBehaviour
{
    public AudioMixer audioMixer;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetVolume(float volumen)
    {
        audioMixer.SetFloat("volumen", Mathf.Log10(volumen) * 5);
        
    }
}
