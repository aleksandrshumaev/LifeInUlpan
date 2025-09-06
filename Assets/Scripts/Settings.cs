using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    float _soundVolume;
    float _musicVolume;
    public delegate void OnVolumeChanged();
    OnVolumeChanged _onChangingMusicVolumeCallBack;
    OnVolumeChanged _onChangingSoundVolumeCallBack;
    AudioSource _audioSource;

    public float SoundVolume { get => _soundVolume;}
    public float MusicVolume { get => _musicVolume;}
    public OnVolumeChanged OnChangingMusicVolumeCallBack { get => _onChangingMusicVolumeCallBack; set => _onChangingMusicVolumeCallBack = value; }
    public OnVolumeChanged OnChangingSoundVolumeCallBack { get => _onChangingSoundVolumeCallBack; set => _onChangingSoundVolumeCallBack = value; }

    // Start is called before the first frame update
    public void SetMusicVolume(float value)
    {

        _audioSource.volume = value;
        /*_musicVolume =value;

        if(OnChangingMusicVolumeCallBack != null)
        {
            OnChangingMusicVolumeCallBack.Invoke();
        }*/
    }
    public void SetSoundVolume(float value)
    {

        _soundVolume = value;
        if(OnChangingSoundVolumeCallBack != null)
        {
            OnChangingSoundVolumeCallBack.Invoke();
        }
    }
    void Start()
    {
        _soundVolume = 1;
        _musicVolume = 1;

        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
