using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeleccionArma : MonoBehaviour {

    GameObject player;
    GameObject ekeyicon;

    public GameObject SeleccionArmaUI;
    
    void Awake ()
    {
        ekeyicon = transform.GetChild(0).gameObject;
        player = GameObject.FindWithTag("Player");
	}
	
	void Update () {
        // Muestra el menú cuando el jugador se acerca y pulsa E
        if (Vector2.Distance(transform.position, player.transform.position) <= 1)
        {
            ekeyicon.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                FindObjectOfType<AudioManager>().Play("Chest");
                SeleccionArmaUI.SetActive(true);
                Time.timeScale = 0f;
            }
        } else
        {
            ekeyicon.SetActive(false);
        }
	}

    public void ElegirEspada()
    {
        SeleccionArmaUI.SetActive(false);
        player.GetComponent<PlayerController>().EquiparArma("Sword");
        GameManager.instance.GetComponent<GameManager>().CambiarImagenArma("Sword");
        Time.timeScale = 1f;
    }

    public void ElegirHacha()
    {
        SeleccionArmaUI.SetActive(false);
        player.GetComponent<PlayerController>().EquiparArma("Axe");
        GameManager.instance.GetComponent<GameManager>().CambiarImagenArma("Axe");
        Time.timeScale = 1f;
    }

    public void ElegirArco()
    {
        SeleccionArmaUI.SetActive(false);
        player.GetComponent<PlayerController>().EquiparArma("Bow");
        GameManager.instance.GetComponent<GameManager>().CambiarImagenArma("Bow");
        Time.timeScale = 1f;
    }
}
