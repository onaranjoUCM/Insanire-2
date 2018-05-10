using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    float volume;
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pausa();
            }
        }
        if (GameIsPaused)
        {
            Time.timeScale = 0f;
        }
	}

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        AudioListener.volume = 1f;

    }

    void Pausa ()
    {
        pauseMenuUI.SetActive(true);        
        GameIsPaused = true;
        AudioListener.volume = 0.3f;
    }
    public void MenuInicio()
    {
        AudioListener.volume = 1f;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Application.LoadLevel("MenuInicio");
        FindObjectOfType<AudioManager>().Play("MenuMusic");
    }

}
