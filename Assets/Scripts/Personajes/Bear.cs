using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : MonoBehaviour {

    public GameObject salida;

	void Update () {
		if (gameObject.GetComponent<Enemy>().health == 0)
        {
            salida.SetActive(true);
        }
	}
}
