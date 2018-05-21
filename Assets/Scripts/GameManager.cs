using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

<<<<<<< HEAD
    private string character = "Clarisse";
    private GameObject player;
=======
    private string character;
    private int puntos = 0;
>>>>>>> master

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

<<<<<<< HEAD
        player = GameObject.FindWithTag("Player");
=======
    }

    public void CargarNivel(string nivel)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nivel);
    }

    void OnLevelWasLoaded()
    {
        string escena = SceneManager.GetActiveScene().name;
        if (escena != "MenuInicio" && escena != "Instrucciones" && escena != "SeleccionPersonaje")
        {
            ActualizarPuntos();
            CambiarImagenPersonaje();
            CambiarImagenArma("Punch");
        }
    }

    public string GetCharacter()
    {
        return character;
>>>>>>> master
    }

    public void CambiarImagenPersonaje()
    {
<<<<<<< HEAD
        character = stringCharacter;
    }

    public string GetCharacter()
    {
        return character;
=======
        marco = GameObject.FindWithTag("Marco");
        marco.transform.GetChild(0).gameObject.GetComponent<Text>().text = character;
        if (character == "Delric")
        {
            marco.transform.GetChild(1).GetChild(0).gameObject.GetComponent<Image>().sprite = characterPictures[0];
        }

        if (character == "Clarisse")
        {
            marco.transform.GetChild(1).GetChild(0).gameObject.GetComponent<Image>().sprite = characterPictures[1];
        }
    }

    public void SetCharacter(string stringCharacter)
    {
        character = stringCharacter;
    }

    public void CambiarImagenArma(string arma)
    {
        marco = GameObject.FindWithTag("Marco");

        if (arma == "Punch")
        {
            marco.transform.GetChild(3).GetChild(0).gameObject.GetComponent<Image>().sprite = weaponsPictures[0];
        }

        if (arma == "Sword")
        {
            marco.transform.GetChild(3).GetChild(0).gameObject.GetComponent<Image>().sprite = weaponsPictures[1];
        }

        if (arma == "Axe")
        {
            marco.transform.GetChild(3).GetChild(0).gameObject.GetComponent<Image>().sprite = weaponsPictures[2];
        }

        if (arma == "Bow")
        {
            marco.transform.GetChild(3).GetChild(0).gameObject.GetComponent<Image>().sprite = weaponsPictures[3];
        }
    }

    public void RestartLevel()
    {
        puntos = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
>>>>>>> master
    }

    public string EscenaActual()
    {
        return SceneManager.GetActiveScene().name;
    }

    public void IncrementarPuntos(int incremento)
    {
        puntos = puntos + incremento;
        ActualizarPuntos();
    }

    public void ActualizarPuntos()
    {
        GameObject.FindWithTag("txtPuntos").GetComponent<Text>().text = "Puntos: " + puntos;
    }

    public int GetPuntos()
    {
        return puntos;
    }
}
