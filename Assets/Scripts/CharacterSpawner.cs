using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour {

    public GameObject[] Characters;
    
	void Awake () {
        //Instantiate(Characters[SeleccionPersonaje.PlayerNum], gameObject.transform.position, gameObject.transform.rotation);
	}
}
