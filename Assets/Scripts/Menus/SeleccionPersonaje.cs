using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeleccionPersonaje : MonoBehaviour {

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
