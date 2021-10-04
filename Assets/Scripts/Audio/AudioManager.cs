using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    public static AudioManager instance;

    private void Awake()
    {
        //if (instance == null)
        //{
        //    instance = this;
        //} else
        //{
        //    Destroy(gameObject);
        //    return;
        //}

        //DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Update()
    {
        //if (Application.loadedLevelName == "Level Select")
        //{
        //    Destroy(this.gameObject);
        //}
    }
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s.isMusic)
        {
            s.source.Play();

        }
        if (s.isMusic && PlayerPrefs.HasKey("Music") && PlayerPrefs.GetInt("Music") == -1)
        {
            s.source.mute = true;
        } else if (s.isSFX && PlayerPrefs.HasKey("SFX") && PlayerPrefs.GetInt("SFX") == 1)
        {
            s.source.Play();
        }
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            return;
        }
        s.source.Stop();

    }

    public void Mute(string name, bool mute)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        
        if (s == null)
        {
            return;
        }
        s.source.mute = mute;
    }
}
