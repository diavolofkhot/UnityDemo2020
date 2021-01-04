using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bed : showCanvas//MonoBehaviour
{
    Animator animator;
    public bool sleep=false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        canvas = GetComponentInChildren<CanvasGroup>();
        canvas.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (pressed) StartCoroutine(fade());
        animator.SetBool("sleep", pressed);
        if (isCollide && exit)
        {
            StartCoroutine(fade());
        }
        if (exit && canvas.alpha > 0.0f)
        {
            //Debug.Log("in");
            StartCoroutine(fade());
        }
    }

}
