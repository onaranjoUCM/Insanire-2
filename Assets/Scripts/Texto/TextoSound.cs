using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextoSound : MonoBehaviour
{
    public GameObject Inquisidor;
    private Vector3 offset;
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
        offset = transform.position - Inquisidor.transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && cajatexto.activeInHierarchy && pausa)
        {
            cajatexto.SetActive(false);
            Time.timeScale = 1f;
        }
        transform.position = Inquisidor.transform.position + offset;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<AudioManager>().Stop("ThemeNivel3");
        AudioSource audio = GetComponentInChildren<AudioSource>();
        if (collision.tag == "Player" && activo)
        {
            audio.Play();
            activo = false;
            if (pausa)
            {
                Time.timeScale = 0f;
            }

            if (puerta != null)
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