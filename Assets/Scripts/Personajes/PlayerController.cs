﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    static bool HabilidadActivada = false;
    static bool MuerteJugador = false;

    public float speed = 5;
    public int health = 100;
    public RuntimeAnimatorController[] playerAnimators;
    public GameObject flecha;

    private string armaEquipada;
    private string character;
    private int damage;
    private int Carga;

    protected SpriteRenderer spriteRenderer;
    protected Rigidbody2D rb2d;
    protected Vector2 velocity;
    protected Collider2D weaponCollider;
    protected Animator animator;
    protected ContactFilter2D contactFilter;
    protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];

    //Delric Hability
    public GameObject HitboxSp;
    private int Descarga = 0;

    public Stat Energy;
    public Stat Health;

    void Awake()
    {
        // Inicializa las estadisticas
        Energy.Initialize();
        Health.Initialize();

        // Inicializa componentes
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        weaponCollider = GameObject.FindWithTag("Weapon").GetComponent<Collider2D>();
    }

    void Start()
    {
        // Inicializa al personaje desarmado
        character = GameManager.instance.GetCharacter();
        armaEquipada = "Punch";
        GameManager.instance.CambiarImagenArma(armaEquipada);
        damage = 5;

        if (character == "Delric")
        {
            GetComponent<Animator>().runtimeAnimatorController = playerAnimators[0];
        }

        if (character == "Clarisse")
        {
            GetComponent<Animator>().runtimeAnimatorController = playerAnimators[4];
        }

        // Permite que solo se choque con objetos de la misma capa
        contactFilter.useTriggers = false;
        contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        contactFilter.useLayerMask = true;
    }

    void FixedUpdate()
    {
        if (character == "Delric")
        {
            if (Input.GetKeyDown(KeyCode.K))
            {

                if (HabilidadActivada == false && Energy.currentVal>0)
                {
                    animator.SetTrigger("K");
                    HabilidadActivada = true;
                    FindObjectOfType<AudioManager>().Play("DelricSp");
                }
                else
                {
                    HabilidadActivada = false;
                    HitboxSp.SetActive(false);
                    FindObjectOfType<AudioManager>().Stop("DelricSp");
                }
                        
            }
            if (HabilidadActivada == true)
            {
                  HitboxSp.SetActive(true);
                  Descarga = Descarga + 1;
                  // introducir daño
                 if (Descarga > 15)
                 {
                    Energy.currentVal -= 3;
                    Descarga = 0;
                 }
                 if (Energy.currentVal < 1)
                 {
                    HabilidadActivada = false;
                    HitboxSp.SetActive(false);
                    FindObjectOfType<AudioManager>().Stop("DelricSp");
                }
            }

        }

        if (Energy.CurrentVal < Energy.MaxVal) 
        {
            Carga = Carga + 1;
        }

        if (Carga > 100)
        {
            Energy.CurrentVal += 10;
            Carga = 0;
        }
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            Health.CurrentVal -= 10;

        }        
        if (Health.CurrentVal > 0)
        {
            Move();

            if (Input.GetKeyDown(KeyCode.L) && !animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerAttack"))
            {
                StartCoroutine(Attack());
            }
        }
        else if(MuerteJugador == false)
        {
            animator.SetTrigger("Dead");
            FindObjectOfType<AudioManager>().Play("Muerte");
            HabilidadActivada = false;
            HitboxSp.SetActive(false);
            FindObjectOfType<AudioManager>().Stop("DelricSp");
            MuerteJugador = true;
        }
    }

    protected void Move()
    {
        // Recoge los parámetros del movimiento
        Vector2 move = Vector2.zero;
        move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed * Time.deltaTime;
        float distance = move.magnitude;

        // Da la vuelta al sprite según la dirección
        if ((move.x > 0 && Mathf.Round(transform.rotation.y) == 0) || (move.x < 0 && Mathf.Round(transform.rotation.y) == -1))
        {
            transform.Rotate(0f, 180f, 0f);
        }

        // Activa la animación de caminar
        if (move.x != 0)
        {
            animator.SetTrigger("WalkSide");
        }
        else
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
        int countX = rb2d.Cast(new Vector2(move.x, 0f), contactFilter, hitBuffer, distance);
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
        animator.SetTrigger("Attack");
        if (armaEquipada == "Bow")
        {
            Vector3 posicionFlecha = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);

            if (Mathf.Round(transform.rotation.y) == 0)
            {
                posicionFlecha.x = posicionFlecha.x - 1;
                Instantiate(flecha, posicionFlecha, Quaternion.identity);
            }

            if (Mathf.Round(transform.rotation.y) == -1)
            {
                posicionFlecha.x = posicionFlecha.x + 1;
                flecha.transform.Rotate(0f, 180f, 0f);
                Instantiate(flecha, posicionFlecha, Quaternion.Euler(0,180,0));
            }

        } else
        {
            weaponCollider.enabled = true;
            yield return new WaitForSeconds(0.1f);
            weaponCollider.enabled = false;
        }
    }

    // Reduce la salud en la cantidad pasada por parámetro (Hasta un mínimo de 0)
    public void ReducirSalud(int reduccion)
    {
        Health.CurrentVal -= reduccion;
    }

    // Aumenta la salud en la cantidad pasada por parámetro (Hasta un máximo de 100)
    public void AumentarSalud(int aumento)
    {
        Health.CurrentVal += aumento;
    }

    // Comportamiento del arma al impactar a un enemigo
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().Knockback(1f);
            collision.GetComponent<Enemy>().ReducirSalud(damage);
        }
        if(collision.gameObject == HitboxSp)
        {
            Physics2D.IgnoreLayerCollision(0, 10, true);
        }
    }

    // Cambia el arma equipada
    public void EquiparArma(string arma)
    {
        armaEquipada = arma;

        if (arma == "Sword")
        {
            damage = 10;
            GetComponent<Animator>().runtimeAnimatorController = playerAnimators[1];
        }

        if (arma == "Axe")
        {
            damage = 20;
            GetComponent<Animator>().runtimeAnimatorController = playerAnimators[2];
        }

        if (arma == "Bow")
        {
            damage = 5;
            GetComponent<Animator>().runtimeAnimatorController = playerAnimators[3];
        }
    }

    public int GetDamage()
    {
        return damage;
    }
}
