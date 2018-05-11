using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClarisseSp : MonoBehaviour {
    PlayerController jugador;
    private GameObject Player;
    private Vector3 offset;
    Collider2D Cl_Collider;
    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        transform.position = Player.transform.position;
        Cl_Collider = GetComponent<Collider2D>();
        jugador = Player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.transform.position + offset;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Physics2D.IgnoreLayerCollision(11, 10, true);
        Physics2D.IgnoreLayerCollision(11, 0, true);
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Lobo contacto con jugadora");
            collision.GetComponent<Enemy>().ReducirSalud(30);
            collision.GetComponent<Enemy>().Knockback(2);
        }
    }
    public void Activado()
    {
        Cl_Collider.enabled = !Cl_Collider.enabled;
    }
    public void Desactivar()
    {
        jugador.Cl_Active = false;
    }
}
