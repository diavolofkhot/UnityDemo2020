using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RentHint : Pointer//MonoBehaviour
{
    public Text[] texts;
    // Start is called before the first frame update
    void Start()
    {
        texts = GetComponentsInChildren<Text>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (pointAt) canvas.SetActive(true);
        else canvas.SetActive(false);
    }
}
