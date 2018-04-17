using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeleccionPersonaje : MonoBehaviour {
    /*
    public static int PlayerNum;

    public void FuncionSeleccionPersonaje ( int NumPersonajeSeleccionado)
    {
        PlayerNum = NumPersonajeSeleccionado;
        // Clarisse = 0 y Delric = 1;
    }
    */

    public void FuncionSeleccionPersonaje(int NumPersonajeSeleccionado)
    {
        if (NumPersonajeSeleccionado == 0)
        {
            GameManager.instance.SetCharacter("Clarisse");
        }

        if (NumPersonajeSeleccionado == 1)
        {
            GameManager.instance.SetCharacter("Delric");
        }
    }
}
