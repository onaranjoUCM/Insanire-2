using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour {
    GameObject player;
	
	void Start () {
        player = GameObject.FindWithTag("Player");
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("Vida+");
            Destroy(this.gameObject);
            player.GetComponent<PlayerController>().AumentarSalud(Random.Range(10, 20));
        }
    }
}
