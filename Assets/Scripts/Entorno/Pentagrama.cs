using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pentagrama : MonoBehaviour {

    public GameObject palanca;
    public bool completado = false;

    int baldosasColocadas = 0;

	public void CheckSolution()
    {
        if(!completado)
        {
            baldosasColocadas = 0;
            foreach (Transform child in transform)
            {
                float zRotation = Mathf.Round(child.rotation.eulerAngles.z);
                if (zRotation == 0 || zRotation == 360)
                {
                    baldosasColocadas++;
                }
            }

            if (baldosasColocadas == 9)
            {
                completado = true;
                CompletePuzzle();
            }
        }
    }

    void CompletePuzzle()
    {
        palanca.SetActive(true);
    }
}