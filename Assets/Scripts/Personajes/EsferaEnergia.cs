using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsferaEnergia : MonoBehaviour {

    public float speed = 8;
    public int damage = 20;

    GameObject player;
    Transform playerTransform;

    void Start ()
    {
        player = GameObject.FindWithTag("Player");
    }
	
	void Update ()
    {
        playerTransform = player.GetComponent<Transform>();
        transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Weapon")
        {
            Destroy(gameObject);
        }

        if (collision.tag == "Player")
        {
            player.GetComponent<PlayerController>().ReducirSalud(damage);
            Destroy(gameObject);
        }
    }
}
