using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource[] soundEffects;
    // Start is called before the first frame update
    private void Awake() 
    {
        instance = this;
    }

    // Update is called once per frame
    public void PlayEffect(int effectNumber)
    {   
        soundEffects[effectNumber].Stop();
        soundEffects[effectNumber].Play();

    }
}
