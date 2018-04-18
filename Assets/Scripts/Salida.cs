using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salida : MonoBehaviour {

    public string siguienteNivel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameManager.instance.GetComponent<GameManager>().CargarNivel(siguienteNivel);
        }
    }
}
