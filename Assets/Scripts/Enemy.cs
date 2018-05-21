using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 3f;
    public float attackSpeed = 1;
    public int damage = 10;
    public int health = 100;
<<<<<<< HEAD:Assets/Scripts/Enemy.cs
=======
    public GameObject manchaSangre;
    public float distanceToPlayer = 1.2f;
    public int puntos;
    PlayerController sonidos;
>>>>>>> master:Assets/Scripts/Personajes/Enemy.cs

    float distanceToPlayer = 1f;
    float signoVector;
    bool waiting = false;

    Transform playerTransform;
    Rigidbody2D rb2d;
    Animator animator;
    GameObject player;
    Collider2D collider;

    protected ContactFilter2D contactFilter;
    protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];

    void Start()
    {
        // Inicializa variables
        player = GameObject.FindWithTag("Player");
        playerTransform = player.GetComponent<Transform>();
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        collider = GetComponent<BoxCollider2D>();

        // Parámetros para que solo se choque con objetos de la misma capa
        contactFilter.useTriggers = false;
        contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        contactFilter.useLayerMask = true;
    }

    void Update()
    {
        if (GetComponent<SpriteRenderer>().isVisible) {
            if(health > 0) { 
                Move();
            }
            else
            {
<<<<<<< HEAD:Assets/Scripts/Enemy.cs
                animator.SetTrigger("wolfDead");
=======
                dead = true;
                animator.SetTrigger("Dead");
                collider.enabled = false;
                GameManager.instance.IncrementarPuntos(puntos);
>>>>>>> master:Assets/Scripts/Personajes/Enemy.cs
            }
        }
    }

    void Move()
    {
        // Si está alejado del jugador se acerca a él
        if (Vector3.Distance(transform.position, playerTransform.position) > distanceToPlayer)
        {
            // Calcula la nueva posición
            Vector2 move = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);

            // Calcula si debe rotar el objeto
            if ((move.x > transform.position.x && Mathf.Round(transform.rotation.y) == 0) || (move.x < transform.position.x && Mathf.Round(transform.rotation.y) == -1))
            {
                transform.Rotate(0f, 180f, 0f);
            }

            // Comprueba obstáculos a los lados
            if (transform.position.x > move.x) { signoVector = -1; }
            else { signoVector = 1; }

            int countX = rb2d.Cast(new Vector2(signoVector, 0f), contactFilter, hitBuffer, 0.3f);
            for (int i = 0; i < countX; i++)
            {
                if (hitBuffer[i].normal.x != 0)
                {
                    move.x = transform.position.x;
                }
            }

            // Comprueba obstáculos arriba y abajo
            if (transform.position.y > move.y) { signoVector = -1; }
            else { signoVector = 1; }

            int countY = rb2d.Cast(new Vector2(0f, signoVector), contactFilter, hitBuffer, 0.1f);
            for (int i = 0; i < countY; i++)
            {
                if (hitBuffer[i].normal.y != 0)
                {
                    move.y = transform.position.y;
                }
            }
            
            // Elige la animacion de movimiento o quieto
            if (Mathf.Approximately(move.magnitude, transform.position.magnitude))
            {
                animator.SetTrigger("wolfIdle");
            } else
            {
                animator.SetTrigger("wolfRun");
            }

            // Realiza el movimiento
            transform.position = move;
        }
        // Si está pegado al jugador le ataca
        else
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        animator.SetTrigger("wolfAttack");
        if(!waiting)
        {
            player.GetComponent<PlayerController>().ReducirSalud(damage);
            waiting = true;
            yield return new WaitForSeconds(attackSpeed);
            waiting = false;
        }
    }

    // Reduce la salud en la cantidad pasada por parámetro (Hasta un mínimo de 0)
    public void ReducirSalud(int reduccion)
    {
        /*
        sonidos = GetComponent<PlayerController>();

        if (sonidos.armaEquipada == "Espada")
        {
            FindObjectOfType<AudioManager>().Play("Espada");
        }
        else if (sonidos.armaEquipada == "Hacha")
        {
            FindObjectOfType<AudioManager>().Play("Hacha");
        }
        else if (sonidos.armaEquipada == "Bow")
        {
            FindObjectOfType<AudioManager>().Play("Arco");
        }
        else if (sonidos.armaEquipada == "Punch")
        {
            FindObjectOfType<AudioManager>().Play("Puñetazo");
        }*/
        FindObjectOfType<AudioManager>().Play("Puñetazo");
        health -= reduccion;
        if (health < 0) { health = 0; }
    }
}
