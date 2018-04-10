using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour {
    [SerializeField]
    private float fillAmount; //es mas optimo supuestamente
    [SerializeField]
    private Image content;

    [SerializeField]
    private float lerpSpeed;

    public float MaxValue { get; set; }
    public float Value
    {
        set
        {
            fillAmount = Calculo(value, 0, MaxValue, 0, 1);
        }
    }
     // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        HandleBar();        
    }
    private void HandleBar()
    {
        if (fillAmount != content.fillAmount)
        {
            content.fillAmount = Mathf.Lerp(content.fillAmount,fillAmount,Time.deltaTime*lerpSpeed);
        }
    }
    private float Calculo(float value, float inMin, float inMax,float outMin, float outMax) // min sule ser 0, y max sera normalmente el mismo
    {

        return (value - inMin) * (outMax - outMin) / (inMax - inMin) - outMin;
        // Ej : (80-0) * (1-0) / (100-0)+0 = 80*1/100 = 0,8(fillAmount)
        //Ej2: (78-0) * (1-0) / (230-0)+0 = 78*1/230 = 0,339(fillAmount) si vidamaxima fuese 230
    }
}
