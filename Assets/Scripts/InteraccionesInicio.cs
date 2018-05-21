using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteraccionesInicio : MonoBehaviour {

    public void IniciarJuego()
    {
        //Application.LoadLevel("Introduccion");
        SceneManager.LoadScene("Introduccion");
    }
    public void Salir()
    {
        Application.Quit();
    }
    public void NuevoPersonaje()
    {
        //Application.LoadLevel("SeleccionPersonaje");
        SceneManager.LoadScene("SeleccionPersonaje");
    }
    public void MenuInicio()
    {
        Time.timeScale = 1f;
        //Application.LoadLevel("MenuInicio");
        SceneManager.LoadScene("MenuInicio");
    }
    public void Intrucciones()
    {
        //Application.LoadLevel("Instrucciones");
        SceneManager.LoadScene("Instrucciones");
    }
    public void ReanudarJuego()
    {
        //Application.LoadLevel("Introduccion"); // temporal
        SceneManager.LoadScene("Introduccion"); // temporal
    }

}
