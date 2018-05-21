using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleFuego : MonoBehaviour {

    public GameObject bat;
    public GameObject AntorchasApagadas;
    public GameObject AntorchasEncendidas;

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
        for (int i = 0; i < contadores.Length; i++)
        {
            //contadores[i]++;
        }

        switch (n) {
            case 1:
                if (contadores[0] <= 4)
                {
                    contadores[0]++;
                    contadores[2]++;
                }
                break;
            case 2:
                if (contadores[1] <= 4)
                {
                    contadores[1]++;
                    contadores[3]++;
                }
                break;
            case 3:
                if (contadores[2] <= 4)
                {
                    contadores[2]++;
                    contadores[1]++;
                }
                break;
            case 4:
                if (contadores[3] <= 4)
                {
                    contadores[3]++;
                    contadores[0]++;
                }
                break;
            case 5:
                ResetPuzzle();
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

    public void ResetPuzzle()
    {
        for (int i = 0; i < contadores.Length; i++)
        {
            contadores[i] = 0;
        }

        for (int i = 0; i < filas.Length; i++)
        {
            for (int j = 0; j < filas[i].childCount; j++)
            {
                filas[i].GetChild(j).gameObject.SetActive(false);
            }
        }
    }

    public void ResolverPuzzle()
    {
        bool resuelto = true;
        bool error = false;
        for (int i = 0; i < filas.Length; i++)
        {
            for (int j = 0; j < filas[i].childCount; j++)
            {
                if (filas[i].GetChild(j).gameObject.activeSelf == false)
                {
                    resuelto = false;
                }

                if (filas[i].GetChild(4).gameObject.activeSelf == true)
                {
                    error = true;
                }
            }
        }

        if (resuelto)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            AntorchasApagadas.SetActive(false);
            AntorchasEncendidas.SetActive(true);
        }

        if (!resuelto && error)
        {
            Instantiate(bat, new Vector3(58.5f, 17, 1), Quaternion.identity);
        }
    }
}
