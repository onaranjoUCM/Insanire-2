using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiedraTiempo : MonoBehaviour {

    GameObject player;
    GameObject ekeyicon;

    void Awake()
    {
        ekeyicon = transform.GetChild(0).gameObject;
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        // Muestra el menú cuando el jugador se acerca y pulsa E
        if (Vector2.Distance(transform.position, player.transform.position) <= 1)
        {
            ekeyicon.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                GameManager.instance.CargarNivel("Nivel Final");
            }
        }
        else
        {
            ekeyicon.SetActive(false);
        }
    }
}
