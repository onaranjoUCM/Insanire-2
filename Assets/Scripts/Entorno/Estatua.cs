using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estatua : MonoBehaviour {

    GameObject player;
    GameObject ekeyicon;
    GameObject puzzle;

    public int boton;

    void Awake()
    {
        ekeyicon = transform.GetChild(0).gameObject;
        player = GameObject.FindWithTag("Player");
        puzzle = transform.parent.parent.gameObject;
    }

    void Update()
    {
        // Muestra el menú cuando el jugador se acerca y pulsa E
        if (Vector2.Distance(transform.position, player.transform.position) <= 1)
        {
            ekeyicon.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                puzzle.GetComponent<PuzzleFuego>().Boton(boton);
            }
        }
        else
        {
            ekeyicon.SetActive(false);
        }
    }
}
