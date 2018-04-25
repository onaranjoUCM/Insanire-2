using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public Sprite[] characterPictures;
    public Sprite[] weaponsPictures;
    public GameObject marco;

    private string character;

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

    }

    public void CargarNivel(string nivel)
    {
        SceneManager.LoadScene(nivel);
    }

    public string GetCharacter()
    {
        return character;
    }

    public void SetCharacter(string stringCharacter)
    {
        character = stringCharacter;
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
            Debug.Log(marco.transform.GetChild(3).childCount);
            marco.transform.GetChild(3).GetChild(0).gameObject.GetComponent<Image>().sprite = weaponsPictures[3];
        }
    }
}
