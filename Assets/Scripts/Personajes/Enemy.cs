using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 3f;
    public int damage = 10;
    public int health = 100;
    public GameObject manchaSangre;
    public float distanceToPlayer = 1.2f;

    float signoVector;
    bool dead = false;

    Transform playerTransform;
    Rigidbody2D rb2d;
    Animator animator;
    GameObject player;

    protected ContactFilter2D contactFilter;
    protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];

    void Start()
    {
        // Inicializa variables
        player = GameObject.FindWithTag("Player");
        playerTransform = player.GetComponent<Transform>();
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();

        // Parámetros para que solo se choque con objetos de la misma capa
        contactFilter.useTriggers = false;
        contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        contactFilter.useLayerMask = true;
    }

    void FixedUpdate()
    {
        if (GetComponent<SpriteRenderer>().isVisible) {
            if(health > 0 && !animator.GetCurrentAnimatorStateInfo(0).IsName("Hit")) { 
                Move();
            }

            if (health == 0 && !dead)
            {
                dead = true;
                animator.SetTrigger("Dead");
                GetComponent<BoxCollider2D>().enabled = false;
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
                animator.SetTrigger("Idle");
            } else
            {
                animator.SetTrigger("Run");
            }

            // Realiza el movimiento
            transform.position = move;
        }
        // Si está pegado al jugador le ataca
        else
        {
            Attack();
        }
    }
    
    void Attack()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Run"))
        {
            animator.SetTrigger("Attack");
            player.GetComponent<PlayerController>().ReducirSalud(damage);
        }
    }

    // Reduce la salud en la cantidad pasada por parámetro (Hasta un mínimo de 0)
    public void ReducirSalud(int reduccion)
    {
        health -= reduccion;
        if (health < 0) { health = 0; }
    }

    public void Knockback(float distancia)
    {
        if (health > 0)
        {
            animator.SetTrigger("Hit");
            Vector3 posicion = transform.position;
            Instantiate(manchaSangre, posicion, Quaternion.identity);

            // Determina hacia donde le están empujando
            if (Mathf.Round(transform.rotation.y) == 0)
            {
                posicion.x += distancia;
            }

            if (Mathf.Round(transform.rotation.y) == -1)
            {
                posicion.x -= distancia;
            }

            // Comprueba obstáculos

            if (transform.position.x > posicion.x) { signoVector = -1; }
            else { signoVector = 1; }

            int countX = rb2d.Cast(new Vector2(signoVector, 0f), contactFilter, hitBuffer, distancia);
            for (int i = 0; i < countX; i++)
            {
                if (hitBuffer[i].normal.x != 0)
                {
                    posicion.x = transform.position.x;
                }
            }
            transform.position = posicion;
        }
    }
}
