using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelricSpCollider : MonoBehaviour {

    public bool DesactivarColision = false;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Lobo contacto con jugador");
            collision.GetComponent<Enemy>().ReducirSalud(1);
        }
        //Physics2D.IgnoreLayerCollision(0, 10, true);
    }
}
