using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    private string character = "Clarisse";
    private GameObject player;

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

        player = GameObject.FindWithTag("Player");
    }

    public void SetCharacter(string stringCharacter)
    {
        character = stringCharacter;
    }

    public string GetCharacter()
    {
        return character;
    }
}
