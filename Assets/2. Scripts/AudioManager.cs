using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    Dictionary<string, AudioClip> BGMList;
    Dictionary<string, AudioClip> SFXList;

    AudioSource bgmAudioSource;
    AudioSource sfxAudioSource;

    public void Init()
    {
        bgmAudioSource = gameObject.AddComponent<AudioSource>();
        sfxAudioSource = gameObject.AddComponent<AudioSource>();

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

        if (bgmAudioSource.isPlaying)
            bgmAudioSource.Stop();
        
        bgmAudioSource.clip = bgm;
        bgmAudioSource.loop = true;
        bgmAudioSource.Play();
    }

    public void PlaySFX(string sfxName)
    {
        SFXList.TryGetValue(sfxName, out AudioClip sfx);

        if (sfxAudioSource.isPlaying)
            sfxAudioSource.Stop();

        sfxAudioSource.clip = sfx;
        sfxAudioSource.loop = false;
        sfxAudioSource.Play();
    }
}
