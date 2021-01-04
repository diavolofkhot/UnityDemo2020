using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : showCanvas//MonoBehaviour
{
    public bool opened=false,opening=false;
    public Animator animator;
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
        animator.SetBool("opened", opened);
        animator.SetBool("opening", opening);
        if (pressed) StartCoroutine(fade());
        if (isCollide && exit)
        {
            StartCoroutine(fade());
        }
        //pressed = false;
    }
}
