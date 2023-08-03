using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioMangaer : MonoBehaviour
{
    public Sound[] sounds;

    // Start is called before the first frame update
    void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.clip = s.clip;
            s.source.loop = s.loop;
        }
    }

    public void Start()
    {
        Play("theme");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.Log("Ne postoji zvuk sa tim imenom");
            return;
        }
        
        s.source.Play();
    }
}
