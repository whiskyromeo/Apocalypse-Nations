using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using System.Collections.Generic;
using System.Linq;

// initial Author Tyler
public class AudioManager {

    #region Fields    
    static AudioManager instance;
    public AudioSource backgroundMusicAudioSource;
    public AudioSource sfxAudioSource;
    public AudioMixer masterAudioMixer;
    public AudioMixer BackgroundAudioMixer;
    public AudioMixer SoundEffectAudioMixer;

    #region Audio Clips

    #endregion
    #endregion

    #region Properites
    /// <summary>
    /// gets the instance of the audio manager
    /// </summary>
    /// <returns>audio manager</returns>
    public AudioManager Instance()
    {
        if (instance != null)
        {
            return new AudioManager();
        }
        else
            return instance;
    }
    /// <summary>
    /// gets the background audio source
    /// </summary>
    public AudioSource BackgroundAudioSource
    { get; private set; }

    /// <summary>
    /// gets the sound effect audio source
    /// </summary>
    public AudioSource SFXAudioSource
    { get; private set; }
    #endregion

    void Awake()
    {
        #region LoadAudioClips

        #endregion
        
    }
}
