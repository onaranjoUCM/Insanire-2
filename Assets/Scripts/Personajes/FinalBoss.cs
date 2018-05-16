using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour {

    public GameObject fantasma;
    public RuntimeAnimatorController[] playerAnimators;

    int currentHealth;
    int maxHealth;
    int fase = 1;
    Animator animator;

    private void Awake()
    {
        if (GameManager.instance.GetCharacter() == "Delric")
        {
            GetComponent<Animator>().runtimeAnimatorController = playerAnimators[0];
        }

        if (GameManager.instance.GetCharacter() == "Clarisse")
        {
            GetComponent<Animator>().runtimeAnimatorController = playerAnimators[0];
        }
    }

    void Start () {
        gameObject.GetComponent<Enemy>().health = gameObject.GetComponent<Enemy>().health + GameManager.instance.GetPuntos();
        maxHealth = gameObject.GetComponent<Enemy>().health;
        InvokeRepeating("CheckHealth", 0, 1);
        animator = GetComponentInChildren<Animator>();
    }
	
	void Update () {

        if (currentHealth < (maxHealth / 3) && fase == 1) { Fase2(); }
    }

    void Fase2()
    {
        fase = 2;
        transform.position = new Vector3(0, -1, 0);
        animator.SetTrigger("Fase2");
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Enemy>().speed = 0;

        for (int i = -2; i <= 2; i++)
        {
            Instantiate(fantasma, new Vector3(i * 2, -2, 0), Quaternion.identity);
        }

        Invoke("Fase3", 20);
    }

    void Fase3()
    {
        fase = 3;
        animator.SetTrigger("Fase3");
        GetComponent<BoxCollider2D>().enabled = true;
        GetComponent<Enemy>().speed = 5;
        GetComponent<Enemy>().damage = GetComponent<Enemy>().damage * 2;
        transform.localScale = new Vector3(2, 2, 1);
    }

    void CheckHealth()
    {
        currentHealth = gameObject.GetComponent<Enemy>().health;
    }

    /*
    void CheckEnemies()
    {
        int numeroEnemigos = 0;
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag("Enemy");

        for (int i = 0; i < enemigos.Length; i++)
        {
            if (enemigos[i].GetComponent<Enemy>().health != 0)
            {
                numeroEnemigos++;
            }
        }

        nEnemigos = numeroEnemigos;
    }
    */
}
