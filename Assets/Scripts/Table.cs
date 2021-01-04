using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : showCanvas// MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponentInChildren<CanvasGroup>();
        canvas.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (pressed) StartCoroutine(fade());
        if (isCollide && exit)
        {
            StartCoroutine(fade());
        }
    }
}
