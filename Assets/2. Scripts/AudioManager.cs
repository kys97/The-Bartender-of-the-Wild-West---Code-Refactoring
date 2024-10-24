using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    Dictionary<string, AudioClip> BGMList;

    AudioSource audioSource;

    public void Init()
    {
        audioSource = gameObject.AddComponent<AudioSource>();

        BGMList = new Dictionary<string, AudioClip>();

        LoadBGM();
    }

    void LoadBGM()
    {
        foreach(AudioClip audio in Resources.LoadAll<AudioClip>())
        {

        }
    }

    public void SetBGM()
    {

    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
