using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private Dictionary<string, AudioClip> bgmClips;
    private Dictionary<string, AudioClip> sfxClips;

    private AudioSource bgmAudioSource;
    private AudioSource sfxAudioSource;

    public void Init()
    {
        bgmAudioSource = gameObject.AddComponent<AudioSource>();
        sfxAudioSource = gameObject.AddComponent<AudioSource>();

        bgmClips = LoadClips("1. Audio/BGM");
        sfxClips = LoadClips("1. Audio/SFX");
    }

    private static Dictionary<string, AudioClip> LoadClips(string path)
    {
        AudioClip[] clips = Resources.LoadAll<AudioClip>(path);
        var clipsByName = new Dictionary<string, AudioClip>(clips.Length);
        foreach (AudioClip clip in clips)
        {
            clipsByName.Add(clip.name, clip);
        }
        return clipsByName;
    }

    public void SetBGM(string BGMName)
    {
        bgmClips.TryGetValue(BGMName, out AudioClip bgm);
        PlayClip(bgmAudioSource, bgm, true);
    }

    public void PlaySFX(string sfxName)
    {
        sfxClips.TryGetValue(sfxName, out AudioClip sfx);
        PlayClip(sfxAudioSource, sfx, false);
    }

    private static void PlayClip(AudioSource source, AudioClip clip, bool loop)
    {
        if (source.isPlaying)
            source.Stop();

        source.clip = clip;
        source.loop = loop;
        source.Play();
    }
}
