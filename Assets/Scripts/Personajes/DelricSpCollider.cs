﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelricSpCollider : MonoBehaviour {
    private GameObject Player;
    //private Vector3 offset;
	
	void Start () {
        Player = GameObject.FindWithTag("Player");
        transform.position =Player.transform.position;

    }
	
	void Update () {
       
        transform.position = Player.transform.position /*+ offset*/;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().ReducirSalud(1);
        }
        Physics2D.IgnoreLayerCollision(11, 10, true);
        Physics2D.IgnoreLayerCollision(11, 0, true);
    }
}

