using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteraccionesInicio : MonoBehaviour {

    public void IniciarJuego()
    {
        SceneManager.LoadScene("Introduccion");
    }

    public void Salir()
    {
        Application.Quit();
    }

    public void NuevoPersonaje()
    {
        SceneManager.LoadScene("SeleccionPersonaje");
    }

    public void MenuInicio()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuInicio");
    }

    public void Intrucciones()
    {
        SceneManager.LoadScene("Instrucciones");
    }
}
