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

    [HideInInspector]
    public bool activo = true;

    private void Start()
    {
        if (pausa)
        {
            mensaje = mensaje + " (Pulsa E para continuar)";
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && cajatexto.activeInHierarchy && pausa)
        {
            cajatexto.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && activo)
        {
            activo = false;
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
            Invoke("OcultaTexto", 5f);
        }
    }

    private void OcultaTexto()
    {
        if (cajatexto.GetComponent<Text>().text == mensaje)
        {
            cajatexto.SetActive(false);
        }
    }
}