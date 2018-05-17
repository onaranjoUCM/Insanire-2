using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImagenInicial : MonoBehaviour {
    
	void Start ()
    {
        Time.timeScale = 0f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
