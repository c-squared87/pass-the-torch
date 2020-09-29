using UnityEngine;

[System.Serializable]
public class Sound
{
    [HideInInspector] public AudioSource Source;

    public string Name;
    public AudioClip Clip;

    [Range(0,1)] public float Volume;
    [Range(0.1f,3)] public float Pitch;
    [Range(0,1.1f)] public float Reverb;

    public bool Loop;
}
