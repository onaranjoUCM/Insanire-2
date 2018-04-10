using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 5;
    public int health = 100;

    //public GameObject Espada;
    //public GameObject Hacha;

    protected Rigidbody2D rb2d;
    protected Vector2 velocity;
    protected Collider2D swordcol;
    protected Animator myanimator;
    protected ContactFilter2D contactFilter;
    protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];

    public Stat Energy;

    public Stat Health;

    private int Carga;
    void Awake()
    {
        
        Energy.Initialize();
        Health.Initialize();
        /*
        if (Espada.activeSelf)
        {
            swordcol = GameObject.FindWithTag("sword1").GetComponent<Collider2D>();
        }
        else if (Hacha.activeSelf)
        {
            swordcol = GameObject.FindWithTag("hacha").GetComponent<Collider2D>();
        }
        */
        myanimator = GetComponentInChildren<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        // Permite que solo se choque con objetos de la misma capa
        contactFilter.useTriggers = false;
        contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        contactFilter.useLayerMask = true;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Energy.CurrentVal -= 10;
        }
        if(Energy.CurrentVal < Energy.MaxVal)
        {
            Carga = Carga + 1;
        }
       
        if (Carga > 100)
        {
            Energy.CurrentVal += 10;
            Carga = 0;
        }
        
        if (Input.GetKeyDown(KeyCode.P)) // para comprobar que baja la vida, Omar tienes que meter aqui el el hacerte daño por ser golpeado
        {
            Health.CurrentVal -= 10;
        }
    }

    private void FixedUpdate()
    {
        Move();
        /*
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (Espada.activeSelf) // mira si esta activo la espada
            {
                myanimator.SetTrigger("Attack");

            }
            else if (Hacha.activeSelf)
            {
                myanimator.SetTrigger("HachaAttack");
            }
        }
        */
             
    }

    protected void Move()
    {
        // Recoge los parámetros del movimiento
        Vector2 move = Vector2.zero;
        move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed * Time.deltaTime;
        float distance = move.magnitude;

        // Da la vuelta al sprite según la dirección
        if ((move.x > 0 && Mathf.Round(transform.rotation.y) == -1) || (move.x < 0 && Mathf.Round(transform.rotation.y) == 0)) {
            transform.Rotate(0f, 180f, 0f);
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
    /*
    void attack()
    {
        swordcol.enabled = true;
    }
    
    void noattack()
    {
        swordcol.enabled = false;
        myanimator.ResetTrigger("Attack");
        myanimator.ResetTrigger("HachaAttack");
    }
    */
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
    }
}
