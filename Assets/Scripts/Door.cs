using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour//showCanvas
{
    Animator animator;
    private bool pressed = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //canvas = GetComponentInChildren<CanvasGroup>();
        //canvas.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //if (pressed) StartCoroutine(fade());
        animator.SetBool("openDoor", pressed);
        //if (isCollide && exit)
        //{
        //    StartCoroutine(fade());
        //}
        //pressed = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pressed = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        pressed = false;
    }
}
