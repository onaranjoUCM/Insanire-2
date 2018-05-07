using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour {

    public GameObject spiderling;
    public GameObject puertaFinal;

    bool active = false;

    private void OnBecameVisible()
    {
        if (!active)
        {
            InvokeRepeating("CreateSpiderling", 5, 2);
            Instantiate(puertaFinal, new Vector3(79.5f, 13.5f, 0), Quaternion.identity);
            active = true;
        }
    }

    void CreateSpiderling()
    {
        if (gameObject.GetComponent<Enemy>().health != 0)
        {
            Instantiate(spiderling, transform.position, Quaternion.identity);
        } else
        {
            Destroy(puertaFinal);
        }
    }
}
