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

    private void OnEnable()
    {
        EventsSystem.ADD_StepsChangedListener(StepSound);
        EventsSystem.ADD_GameLoseListener(LoseSound);
        EventsSystem.ADD_GameWinListener(WinSound);
        EventsSystem.ADD_PlayerFailListener(FailSound);
        EventsSystem.ADD_PlayerSuccessListener(SuccessSound);
    }

    private void OnDisable()
    {
        EventsSystem.REMOVE_StepsChangedListener(StepSound);
        EventsSystem.REMOVE_GameLoseListener(LoseSound);
        EventsSystem.REMOVE_GameWinListener(WinSound);
        EventsSystem.REMOVE_PlayerFailListener(FailSound);
        EventsSystem.REMOVE_PlayerSuccessListener(SuccessSound);
    }

    private void SuccessSound() { Play("PowerUp"); }
    private void FailSound() { Play("Fail"); }
    private void WinSound() { Play("Win"); }
    private void LoseSound() { Play("Lose"); }
    private void StepSound(int _numberOfStepsRemaining) { Play("Step");
        Debug.Log(Time.time + "setp"); }

    void Play(string _soundToPlay)
    {
        Sound _s = Array.Find(Sounds, sound => sound.Name == _soundToPlay);

        if (_s == null) { Debug.Log("SOUND " + _soundToPlay + " NOT FOUND"); return; }

        _s.Source.Play();
    }
}
