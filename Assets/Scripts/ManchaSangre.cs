using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManchaSangre : MonoBehaviour {
    
	void Start () {
        transform.GetChild(Random.Range(0, 4)).gameObject.SetActive(true);
    }
}
