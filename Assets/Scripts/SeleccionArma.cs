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
        Time.timeScale = 1f;
        SeleccionArmaUI.SetActive(false);
        Sonido();
        player.GetComponent<PlayerController>().EquiparArma("Sword");
<<<<<<< HEAD:Assets/Scripts/SeleccionArma.cs
=======
        GameManager.instance.GetComponent<GameManager>().CambiarImagenArma("Sword");
        
>>>>>>> master:Assets/Scripts/Menus/SeleccionArma.cs
    }

    public void ElegirHacha()
    {
        Time.timeScale = 1f;
        SeleccionArmaUI.SetActive(false);
        Sonido();
        player.GetComponent<PlayerController>().EquiparArma("Axe");
    }

    public void ElegirArco()
    {
        Time.timeScale = 1f;
        SeleccionArmaUI.SetActive(false);
        Sonido();
        player.GetComponent<PlayerController>().EquiparArma("Bow");
    }
    void Sonido()
    {
        FindObjectOfType<AudioManager>().Play("PickedWeapon");
    }
}
