using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    Dictionary<string, AudioClip> BGMList;
    Dictionary<string, AudioClip> SFXList;

    AudioSource audioSource;

    public void Init()
    {
        audioSource = gameObject.AddComponent<AudioSource>();

        BGMList = new Dictionary<string, AudioClip>();
        SFXList = new Dictionary<string, AudioClip>();

        LoadBGM();
    }

    void LoadBGM()
    {
        foreach(AudioClip audio in Resources.LoadAll<AudioClip>("1. Audio/BGM"))
        {
            BGMList.Add(audio.name, audio);
        }
        foreach (AudioClip audio in Resources.LoadAll<AudioClip>("1. Audio/SFX"))
        {
            SFXList.Add(audio.name, audio);
        }
    }

    public void SetBGM(string BGMName)
    {
        BGMList.TryGetValue(BGMName, out AudioClip bgm);
        audioSource.clip = bgm;
        audioSource.Play();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
