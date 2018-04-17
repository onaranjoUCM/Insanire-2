using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeleccionArma : MonoBehaviour {

    GameObject player;
    GameObject ekeyicon;
    static bool GameIsPaused;

    public GameObject SeleccionArmaUI;
    
    void Awake ()
    {
        ekeyicon = transform.GetChild(0).gameObject;
        player = GameObject.FindWithTag("Player");
        GameIsPaused = false;
	}
	
	void Update () {
        // Detiene el juego mientras se muestra el menú
        if (GameIsPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }

        // Muestra el menú cuando el jugador se acerca y pulsa E
        if (Vector2.Distance(transform.position, player.transform.position) <= 1)
        {
            ekeyicon.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                SeleccionArmaUI.SetActive(true);
                GameIsPaused = true;
            }
        } else
        {
            ekeyicon.SetActive(false);
        }
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

    public void ElegirArco()
    {
        SeleccionArmaUI.SetActive(false);
        GameIsPaused = false;
        player.GetComponent<PlayerController>().EquiparArma("Arco");
    }
}
