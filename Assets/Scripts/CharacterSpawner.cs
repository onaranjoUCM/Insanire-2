using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour {

    public GameObject[] Characters;

	// Use this for initialization
	void Awake () {
        Instantiate(Characters[SeleccionPersonaje.PlayerNum], gameObject.transform.position, gameObject.transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
