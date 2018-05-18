using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Texto : MonoBehaviour
{
    public GameObject cajatexto;
    public string mensaje;
    public bool pausa = false;

    void Start ()
    {

        if (pausa)
        {

            Time.timeScale = 0f;

        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            cajatexto.SetActive(true);
            cajatexto.GetComponent<Text>().text = mensaje;
            Invoke("ocultatexto", 5f);
            gameObject.SetActive(false);
        }

    }
    private void ocultatexto ()
    {
        cajatexto.SetActive(false);
        if (pausa)
        {
            Time.timeScale = 2f;
        }
        
        
    }


}