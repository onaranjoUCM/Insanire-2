using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palanca : MonoBehaviour {

    GameObject player;
    GameObject ekeyicon;

    public GameObject puerta;

    void Awake()
    {
        ekeyicon = transform.GetChild(0).gameObject;
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        // Muestra el menú cuando el jugador se acerca y pulsa E
        if (Vector2.Distance(transform.position, player.transform.position) <= 1 && puerta.activeInHierarchy)
        {
            ekeyicon.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                puerta.SetActive(false);
                // Mostrar texto tipo "Se ha abierto una puerta" o reproducir un sonido
            }
        }
        else
        {
            ekeyicon.SetActive(false);
        }
    }

}
