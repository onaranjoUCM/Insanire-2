using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeleccionArma : MonoBehaviour {
    GameObject player;

    public static bool GameIsPaused;
    public GameObject SeleccionArmaUI;

    // Use this for initialization
    void Awake ()
    {
        player = GameObject.FindWithTag("Player");
        GameIsPaused = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (GameIsPaused == false)
        {
            Time.timeScale = 1f;
        }
        else Time.timeScale = 0f;
	}
    public void ElegirEspada()
    {
        SeleccionArmaUI.SetActive(false);
        GameIsPaused = false;
        player.GetComponent<PlayerController>().EquiparArma("Espada");
    }

    public void ElegirHacha()
    {
        SeleccionArmaUI.SetActive(false);
        GameIsPaused = false;
        player.GetComponent<PlayerController>().EquiparArma("Hacha");
    }
}
