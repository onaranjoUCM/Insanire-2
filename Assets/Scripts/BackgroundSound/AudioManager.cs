﻿using UnityEngine.Audio;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour {
    public Sound[] sounds;
    public static AudioManager instance;
    string sceneName; // coge el nombre de la escena
	// Use this for initialization
	void Awake () {
        Scene currentScene = SceneManager.GetActiveScene(); // coger la escena del momento
        sceneName = currentScene.name;

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
        } if (currentName == "MenuInicio")
        {
            Play("ThemeIntro");
        }
        if(next.name == "Nivel 1")
        {
            Play("ThemeNivel1");
        }
        if (next.name == "MenuInicio")
        {
            Play("MenuMusic");
        }
        if (next.name == "Introduccion")
        {
            Play("ThemeIntro");
        }
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
}
