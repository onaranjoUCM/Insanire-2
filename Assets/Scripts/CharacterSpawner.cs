using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour {

    public GameObject[] Characters;
    public Transform PlayerSpawnPoint;
	// Use this for initialization
	void Start () {
        Instantiate(Characters[SeleccionPersonaje.PlayerNum], PlayerSpawnPoint.position, PlayerSpawnPoint.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
