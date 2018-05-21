using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inquisitor : MonoBehaviour {

    public GameObject EsferaEnergia;
    public GameObject puertaFinal;

    void Start () {
        InvokeRepeating("InvocaEsfera",5, 5);
	}
	
	void InvocaEsfera() {
        if (gameObject.GetComponent<Enemy>().health != 0)
        {
            if (GetComponent<SpriteRenderer>().isVisible)
            {
                Instantiate(EsferaEnergia, transform.position, Quaternion.identity);
            }
        }
        else
        {
            Destroy(puertaFinal);
        }
    }
}