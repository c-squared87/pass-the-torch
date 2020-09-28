using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] Sounds;


    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        if (Instance != this) { Destroy(gameObject); }
        DontDestroyOnLoad(gameObject);

        foreach (Sound sound in Sounds)
        {
            sound.Source = gameObject.AddComponent<AudioSource>();

            sound.Source.clip = sound.Clip;
            sound.Source.volume = sound.Volume;
            sound.Source.pitch = sound.Pitch;
            sound.Source.loop = sound.Loop;

        }

        Play("BackgroundMusic");
    }

    public void Play(string _soundToPlay)
    {
        Sound _s = Array.Find(Sounds, sound => sound.Name == _soundToPlay);

        if (_s == null) { Debug.Log("SOUND " + _soundToPlay + " NOT FOUND"); return; }

        _s.Source.Play();
        Debug.Log("playing...");
    }
}
