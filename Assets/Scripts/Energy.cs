using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour
{
    public GameObject energyCanvas;
    protected Text[] texts;
    public float num;
    // Start is called before the first frame update
    void Start()
    {
        texts = energyCanvas.GetComponentsInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        texts[1].text =num.ToString();
    }
}
