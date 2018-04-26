using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackgroundMusic : MonoBehaviour {

    string sceneName; // coge el nombre de la escena
                      // Use this for initialization
    void Awake () {
        Scene currentScene = SceneManager.GetActiveScene(); // coger la escena del momento
        sceneName = currentScene.name;      
    }
    private void Start()
    {
        if (sceneName == "MenuInicio")
        {
            FindObjectOfType<AudioManager>().Play("MenuMusic");
        }
      /*  if (sceneName == "Introduccion")
        {
            FindObjectOfType<AudioManager>().Play("ThemeIntro");
        }
        if(sceneName == "Nivel 1")
        {
            FindObjectOfType<AudioManager>().Play("ThemeNivel1");
        }*/
    }

    // Update is called once per frame
    void Update () {
        if (sceneName == "MenuInicio")
        {
            FindObjectOfType<AudioManager>().Stop("ThemeIntro");
            FindObjectOfType<AudioManager>().Stop("ThemeNivel1");
        }
        else if (sceneName == "Introduccion")
        {
            FindObjectOfType<AudioManager>().Stop("MenuMusic");
            FindObjectOfType<AudioManager>().Stop("ThemeNivel1");
        }
        else if (sceneName == "Nivel 1")
        {
            FindObjectOfType<AudioManager>().Stop("MenuMusic");
            FindObjectOfType<AudioManager>().Stop("ThemeIntro");
        }
    }
}
