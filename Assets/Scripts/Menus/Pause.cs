using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        Time.timeScale = 0f;
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
        SceneManager.LoadScene("MenuInicio");
        FindObjectOfType<AudioManager>().Play("MenuMusic");
    }

}
