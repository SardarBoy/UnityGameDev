using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;

    public void Awake()
    {
        if (UnityEngine.Object.Equals(instance, null))
        {
            instance = this;
        }
        else
        {
            UnityEngine.Object.Destroy(this.gameObject);
        }

        UnityEngine.Object.DontDestroyOnLoad(this.gameObject);

        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.Volume;
            sound.source.pitch = sound.Pitch;
            sound.source.loop = sound.Loop;
        }
    }

    public void Start()
    {
        Play("Theme");
    }

    public void Play(string name)
    {
        Sound sound = Array.Find(sounds, s => s.name == name);
        if (sound != null && sound.source != null)
        {
            sound.source.Play();
        }
    }
}
