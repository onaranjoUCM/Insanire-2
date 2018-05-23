using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntosA0 : MonoBehaviour {

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!gameObject.GetComponent<Texto>().activo)
            {
                GameManager.instance.SetPuntos(0);
                GameManager.instance.ActualizarPuntos();
            }
        }
    }
}
