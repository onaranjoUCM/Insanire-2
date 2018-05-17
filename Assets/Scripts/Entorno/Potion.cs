using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour {
    GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
        player.GetComponent<PlayerController>().AumentarSalud(Random.Range(8, 30));
    }
}
