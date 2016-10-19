using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

// initial Author Tyler
public class AudioManager {

    #region Fields    
    static AudioManager instance;
    public AudioSource backgroundMusicAudioSource;
    public AudioSource sfxAudioSource;
    public AudioMixer masterAudioMixer;
    public AudioMixer BackgroundAudioMixer;
    public AudioMixer SoundEffectAudioMixer;
    #endregion

    #region Properites
    public AudioManager Instance()
    {
        if (instance != null)
        {
            return new AudioManager();
        }
        else
            return instance;
    }
    #endregion

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
