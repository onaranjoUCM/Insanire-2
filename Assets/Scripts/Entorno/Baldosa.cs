using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baldosa : MonoBehaviour {

    bool pisada = false;
    GameObject pentagrama;

    private void Start()
    {
        pentagrama = transform.parent.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !pisada && !pentagrama.GetComponent<Pentagrama>().completado)
        {
            pisada = true;
            transform.Rotate(0f, 0f, 90f);
        }
        pentagrama.GetComponent<Pentagrama>().CheckSolution();
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && pisada)
        {
            pisada = false;
        }
    }
}
