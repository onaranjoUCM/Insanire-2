using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleFuego : MonoBehaviour {

    public GameObject bat;
    public GameObject AntorchasApagadas;

    Transform[] filas = new Transform[4];
    int[] contadores = {0, 0, 0, 0};

    void Start () {
        filas[0] = transform.GetChild(1);
        filas[1] = transform.GetChild(2);
        filas[2] = transform.GetChild(3);
        filas[3] = transform.GetChild(4);
    }
	
    public void Boton(int n)
    {
        switch (n) {
            case 1:
                if (contadores[2] < 5)
                {
                    contadores[2]++;
                } else
                {
                    Instantiate(bat, new Vector3(65f, 14, 1), Quaternion.identity);
                }
                break;
            case 2:
                if (contadores[3] < 5)
                {
                    contadores[3]++;
                }
                else
                {
                    Instantiate(bat, new Vector3(65f, 14, 1), Quaternion.identity);
                }
                break;
            case 3:
                if (contadores[1] < 5)
                {
                    contadores[1]++;
                }
                else
                {
                    Instantiate(bat, new Vector3(65f, 14, 1), Quaternion.identity);
                }
                break;
            case 4:
                if (contadores[0] < 5)
                {
                    contadores[0]++;
                }
                else
                {
                    Instantiate(bat, new Vector3(65f, 14, 1), Quaternion.identity);
                }
                break;
        }
        
        ActualizaPuzzle();
        ResolverPuzzle();
    }

    public void ActualizaPuzzle()
    {
        for (int i = 0; i < filas.Length; i++)
        {
            for (int j = 0; j < contadores[i]; j++)
            {
                filas[i].GetChild(j).gameObject.SetActive(true);
            }
        }
    }

    public void ResolverPuzzle()
    {
        bool resuelto = true;
        for (int i = 0; i < filas.Length; i++)
        {
            for (int j = 0; j < filas[i].childCount; j++)
            {
                if (filas[i].GetChild(j).gameObject.activeSelf == false)
                {
                    resuelto = false;
                }
            }
        }

        if (resuelto)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            AntorchasApagadas.SetActive(false);
        }
    }
}
