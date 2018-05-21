using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Marco : MonoBehaviour
{

    public Sprite[] characterPictures;
    public Sprite[] weaponsPictures;

    public void CambiarImagenPersonaje(string personaje)
    {
        if (personaje == "Delric")
        {
            transform.GetChild(1).GetChild(0).gameObject.GetComponent<Image>().sprite = characterPictures[0];
        }

        if (personaje == "Clarisse")
        {
            transform.GetChild(1).GetChild(0).gameObject.GetComponent<Image>().sprite = characterPictures[1];
        }
    }

    public void CambiarNombre(string nombre)
    {
        transform.GetChild(0).gameObject.GetComponent<Text>().text = nombre;
    }

    public void CambiarImagenArma(string arma)
    {
        if (arma == "Espada")
        {
            transform.GetChild(1).GetChild(3).gameObject.GetComponent<Image>().sprite = weaponsPictures[0];
        }

        if (arma == "Hacha")
        {
            transform.GetChild(1).GetChild(3).gameObject.GetComponent<Image>().sprite = weaponsPictures[1];
        }

        if (arma == "Arco")
        {
            transform.GetChild(1).GetChild(3).gameObject.GetComponent<Image>().sprite = weaponsPictures[2];
        }
    }
}
