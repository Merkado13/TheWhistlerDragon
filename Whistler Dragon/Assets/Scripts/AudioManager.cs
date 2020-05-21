using UnityEngine.Audio;
using System;
using UnityEngine;

using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;
    

    private void Awake()
    {

       // DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
            s.source.spatialBlend = 1;
            s.source.spatialize = true;
            s.source.spatializePostEffects = true;
        }
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name.Contains("Level1"))
        {
            Play("Countdown1");
        }     

    }

    public void Play(string name) {
        Sound s =  Array.Find(sounds, sound => sound.name == name);
        if (s == null) {
            Debug.LogWarning("Sound " +name+ " not found!");
            return; 
        }
        if (!s.source.isPlaying)
        {            
            s.source.Play();   
        }
            
    }

}
