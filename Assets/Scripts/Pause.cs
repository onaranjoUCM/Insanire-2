using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
	
	// Update is called once per frame
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
                Time.timeScale = 0f;
            }
        }
		
	}
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }
    void Pausa ()
    {
        pauseMenuUI.SetActive(true);
       
        GameIsPaused = true;
    }
    
}
