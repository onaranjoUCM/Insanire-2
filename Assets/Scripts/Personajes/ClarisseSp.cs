using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClarisseSp : MonoBehaviour {
    private GameObject Player;
    private Vector3 offset;
    // Use this for initialization
    void Start()
    {
        Debug.Log("se llama Cl");
        Player = GameObject.FindWithTag("Player");
        transform.position = Player.transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.transform.position + offset;
    }
}
