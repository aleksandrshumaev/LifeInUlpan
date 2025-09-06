using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound 
{
    [SerializeField] AudioClip _clip;
    [Range(0f, 1f)]
    [SerializeField] float _volume;
    [Range (0.1f,3f)]
    [SerializeField] float _pitch;
    AudioSource _source;

    public AudioSource Source { get => _source; set => _source = value; }
    public AudioClip Clip { get => _clip; set => _clip = value; }
    public float Volume { get => _volume; set => _volume = value; }
}
