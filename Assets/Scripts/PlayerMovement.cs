using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 5;
    public int health = 100;

    private string armaEquipada = "Punch";
    private string animacionArma = "PlayerPunch";
    private int damage = 5;

    protected SpriteRenderer spriteRenderer;
    protected Rigidbody2D rb2d;
    protected Vector2 velocity;
    protected Collider2D weaponCollider;
    protected Animator animator;
    protected ContactFilter2D contactFilter;
    protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];

    void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        weaponCollider = GameObject.FindWithTag("Weapon").GetComponent<Collider2D>();
    }

    void Start()
    {
        // Permite que solo se choque con objetos de la misma capa
        contactFilter.useTriggers = false;
        contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        contactFilter.useLayerMask = true;
    }

    private void FixedUpdate()
    {
        if (health > 0)
        {
            Move();

            if (Input.GetKeyDown(KeyCode.L) && !animator.GetCurrentAnimatorStateInfo(0).IsName(animacionArma))
            {
                StartCoroutine(Attack());
            }
        } else
        {
            animator.SetTrigger("Dead");
        }
    }

    protected void Move()
    {
        // Recoge los parámetros del movimiento
        Vector2 move = Vector2.zero;
        move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed * Time.deltaTime;
        float distance = move.magnitude;

        // Da la vuelta al sprite según la dirección
        if ((move.x > 0 && Mathf.Round(transform.rotation.y) == 0) || (move.x < 0 && Mathf.Round(transform.rotation.y) == -1)) {
            transform.Rotate(0f, 180f, 0f);
        }

        // Activa la animación de caminar
        if (move.x != 0)
        {
            animator.SetTrigger("WalkSide");
        } else
        {
            if (move.y > 0)
            {
                animator.SetTrigger("WalkUp");
            }

            if (move.y < 0)
            {
                animator.SetTrigger("WalkDown");
            }

            if (move.y == 0)
            {
                animator.SetTrigger("Idle");
            }
        }

        // Comprueba obstáculos a los lados
        int countX = rb2d.Cast(new Vector2 (move.x, 0f), contactFilter, hitBuffer, distance);
        for (int i = 0; i < countX; i++)
        {
            if (hitBuffer[i].normal.x != 0)
            {
                move.x = 0f;
            }
        }

        // Comprueba obstáculos arriba y abajo
        int countY = rb2d.Cast(new Vector2(0f, move.y), contactFilter, hitBuffer, distance);
        for (int i = 0; i < countY; i++)
        {
            if (hitBuffer[i].normal.y != 0)
            {
                move.y = 0f;
            }
        }
        
        // Realiza el movimiento
        rb2d.position = rb2d.position + move;
    }

    // Ataque
    IEnumerator Attack()
    {
        animator.SetTrigger("Punch");
        weaponCollider.enabled = true;
        yield return new WaitForSeconds(0.1f);
        weaponCollider.enabled = false;
    }

    // Reduce la salud en la cantidad pasada por parámetro (Hasta un mínimo de 0)
    public void ReducirSalud(int reduccion)
    {
        health -= reduccion;
        if (health < 0) { health = 0; }
        GameManager.instance.ActualizarTxtSalud(health);
    }

    // Aumenta la salud en la cantidad pasada por parámetro (Hasta un máximo de 100)
    public void AumentarSalud(int aumento)
    {
        health += aumento;
        if (health > 100) { health = 100; }
        GameManager.instance.ActualizarTxtSalud(health);
    }
    
    // Comportamiento del arma al impactar a un enemigo
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().ReducirSalud(damage);
        }
    }

    // Cambia el arma equipada
    public void EquiparArma(string arma)
    {
        armaEquipada = arma;

        if (arma == "Espada")
        {
            animacionArma = "PlayerSword";
            damage = 10;
        }

        if (arma == "Hacha")
        {
            animacionArma = "PlayerAxe";
            damage = 20;
        }

        if (arma == "Arco")
        {
            animacionArma = "PlayerBow";
            damage = 5;
        }
    }
    
}
