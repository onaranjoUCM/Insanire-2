using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spiderling : MonoBehaviour {
    
	void Start () {
        GetComponent<BoxCollider2D>().enabled = false;
        Invoke("ActivaCollider", 0.5f);
	}
	
	void ActivaCollider()
    {
        GetComponent<BoxCollider2D>().enabled = true;
    }
}
