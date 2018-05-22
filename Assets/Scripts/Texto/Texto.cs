using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Texto : MonoBehaviour
{
    public GameObject cajatexto;
    public string mensaje;
    public bool pausa = false;
    public GameObject puerta;

    bool activo = true;

    private void Start()
    {
        if (pausa)
        {
            mensaje = mensaje + " (Pulsa E para continuar)";
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && cajatexto.active)
        {
            cajatexto.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && activo)
        {
            if (pausa)
            {
                Time.timeScale = 0f;
            }

            if(puerta != null)
            {
                puerta.SetActive(false);
            }

            cajatexto.SetActive(true);
            cajatexto.GetComponent<Text>().text = mensaje;
            activo = false;
            Invoke("OcultaTexto", 5f);
        }
    }

    private void OcultaTexto()
    {
        cajatexto.SetActive(false);
    }
}