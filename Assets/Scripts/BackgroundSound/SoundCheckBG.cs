using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundCheckBG : MonoBehaviour {
    string sceneName; // coge el nombre de la escena
                      // Use this for initialization
    void Awake()
    {
        Scene currentScene = SceneManager.GetActiveScene(); // coger la escena del momento
        sceneName = currentScene.name;
    }

    // Update is called once per frame
    void Update()
    {
        if (sceneName == "MenuInicio")
        {
            FindObjectOfType<AudioManager>().Stop("ThemeIntro");
            FindObjectOfType<AudioManager>().Stop("ThemeNivel1");
            FindObjectOfType<AudioManager>().Stop("ThemeNivel3");
            FindObjectOfType<AudioManager>().Stop("ThemeNivelF");
        }
        else if (sceneName == "Introduccion")
        {
            FindObjectOfType<AudioManager>().Stop("MenuMusic");
            FindObjectOfType<AudioManager>().Stop("ThemeNivel1");
            FindObjectOfType<AudioManager>().Stop("ThemeNivel2");
            FindObjectOfType<AudioManager>().Stop("ThemeNivel3");
            FindObjectOfType<AudioManager>().Stop("ThemeNivelF");
        }
        else if (sceneName == "Nivel 1")
        {
            FindObjectOfType<AudioManager>().Stop("MenuMusic");
            FindObjectOfType<AudioManager>().Stop("ThemeIntro");
            FindObjectOfType<AudioManager>().Stop("ThemeNivel2");
            FindObjectOfType<AudioManager>().Stop("ThemeNivel3");
            FindObjectOfType<AudioManager>().Stop("ThemeNivelF");
        }
        else if (sceneName == "Nivel 2")
        {
            FindObjectOfType<AudioManager>().Stop("MenuMusic");
            FindObjectOfType<AudioManager>().Stop("ThemeIntro");
            FindObjectOfType<AudioManager>().Stop("ThemeNivel1");
            FindObjectOfType<AudioManager>().Stop("ThemeNivel3");
            FindObjectOfType<AudioManager>().Stop("ThemeNivelF");
        }
        else if (sceneName == "Nivel 3")
        {
            FindObjectOfType<AudioManager>().Stop("MenuMusic");
            FindObjectOfType<AudioManager>().Stop("ThemeIntro");
            FindObjectOfType<AudioManager>().Stop("ThemeNivel1");
            FindObjectOfType<AudioManager>().Stop("ThemeNivel2");
            FindObjectOfType<AudioManager>().Stop("ThemeNivelF");
        }
        else if (sceneName == "Nivel Final")
        {
            FindObjectOfType<AudioManager>().Stop("MenuMusic");
            FindObjectOfType<AudioManager>().Stop("ThemeIntro");
            FindObjectOfType<AudioManager>().Stop("ThemeNivel1");
            FindObjectOfType<AudioManager>().Stop("ThemeNivel2");
            FindObjectOfType<AudioManager>().Stop("ThemeNivel3");
        }
    }

}
