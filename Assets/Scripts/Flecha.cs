using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flecha : MonoBehaviour {

    public float speed = 5;

    private int arrowDamage;

    private void Start()
    {
        arrowDamage = GameObject.FindWithTag("Player").GetComponent<PlayerController>().GetDamage();
        if (Mathf.Round(transform.rotation.y) == 0)
        {
            speed = -speed;
        }
    }

    private void Update()
    {
        transform.position = transform.position + new Vector3(speed,0,0) * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().ReducirSalud(arrowDamage);
        }
        Destroy(gameObject);
    }
}
