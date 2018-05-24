using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public Sprite[] characterPictures;
    public Sprite[] SpPictures;
    public Sprite[] weaponsPictures;
    public GameObject SpIcon;
    public GameObject marco;

    private string character;
    private int puntos = 0;
    private int muertes = 0;

    string sceneName; // coge el nombre de la escena
    void Awake()
    {
        Scene currentScene = SceneManager.GetActiveScene(); // coger la escena del momento
        sceneName = currentScene.name;
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        SceneManager.activeSceneChanged += ChangedActiveScene;
    }
    private void ChangedActiveScene(Scene current, Scene next)
    {
        string currentName = current.name;

        if (currentName == null)
        {
            // CurrentScene has been removed
            currentName = "Replaced";
        }
        string escena = SceneManager.GetActiveScene().name;
        if (next.name != currentName && escena != "MenuInicio" && escena != "Instrucciones" && escena != "SeleccionPersonaje") 
        {
            ActualizarMuertes();
            ActualizarPuntos();
        }
        }
        public void CargarNivel(string nivel)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nivel);
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        string escena = SceneManager.GetActiveScene().name;
        if (escena != "MenuInicio" && escena != "Instrucciones" && escena != "SeleccionPersonaje")
        {
            ActualizarMuertes();
            ActualizarPuntos();
            CambiarImagenPersonaje();
            CambiarImagenArma("Punch");
        }
    }

    public string GetCharacter()
    {
        return character;
    }

    public void CambiarImagenPersonaje()
    {
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

    public void CambiarIconoSp()
    {
        SpIcon.SetActive(true);
        if (character == "Delric")
        {
            SpIcon.GetComponent<Image>().sprite = SpPictures[0];
        }

        if (character == "Clarisse")
        {
            SpIcon.GetComponent<Image>().sprite = SpPictures[1];
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
    public void IncrementarMuertes(int incremento)
    {
        muertes = muertes + incremento;
    }

    public void ActualizarPuntos()
    {
        GameObject.FindWithTag("txtPuntos").GetComponent<Text>().text = "Almas: " + puntos;
    }
    public void ActualizarMuertes()
    {
        GameObject.FindWithTag("txtMuertes").GetComponent<Text>().text = "Muertes: " +muertes;
    }

    public int GetPuntos()
    {
        return puntos;
    }

    public void SetPuntos(int nuevosPuntos)
    {
        puntos = nuevosPuntos;
    }
}
