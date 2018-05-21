using UnityEngine.Audio;
using UnityEngine;
using System;
<<<<<<< HEAD:Assets/Scripts/AudioManager.cs
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
>>>>>>> master:Assets/Scripts/BackgroundSound/AudioManager.cs

public class AudioManager : MonoBehaviour {
    public Sound[] sounds;
    public static AudioManager instance;
	// Use this for initialization
	void Awake () {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
		foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
	}
    private void Start()
    {
<<<<<<< HEAD:Assets/Scripts/AudioManager.cs
        Play("Theme");
=======
        if (sceneName == "MenuInicio")
        {
            Play("MenuMusic");
        }
        SceneManager.activeSceneChanged += ChangedActiveScene;    
    }
    private void ChangedActiveScene(Scene current, Scene next)
    {
        string currentName = current.name;

        if (currentName == null)
        {
            // CurrentScene has been removed
            currentName = "Replaced";
        }
        if (currentName == "MenuInicio")
        {
            Play("ThemeIntro");
        }
        if(next.name == "Nivel 1")
        {
            Play("ThemeNivel1");
        }
        else if (next.name == "MenuInicio")
        {
            Play("MenuMusic");
        }
        else if (next.name == "Introduccion")
        {
            Play("ThemeIntro");
        }
        else if (next.name == "Nivel 2")
        {
            Play("ThemeNivel2");
        }
        else if (next.name == "Nivel 3")
        {
            Play("ThemeNivel3");
        }
        else if (next.name == "Nivel Final")
        {
            Play("ThemeNivelF");
        }

>>>>>>> master:Assets/Scripts/BackgroundSound/AudioManager.cs
    }
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();

    }
<<<<<<< HEAD:Assets/Scripts/AudioManager.cs
=======
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found, so cannot be stopped!");
            return;
        }
        s.source.Stop();
    }

>>>>>>> master:Assets/Scripts/BackgroundSound/AudioManager.cs
}
