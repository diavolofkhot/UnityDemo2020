using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showCanvas : MonoBehaviour
{
    //private Animator animator;
    public GameObject player;
    public bool pressed=false;
    protected bool isCollide=false;
    protected bool exit = true;
    //stay=false;
    protected CanvasGroup canvas;
    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
        canvas = GetComponentInChildren<CanvasGroup>();
        canvas.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        { 
        // Vector3 vDis = (transform.position - player.transform.position);
        // vDis.y = 0;
        // float dis = vDis.magnitude;
        // Debug.Log(transform.position + " " + player.transform.position + " " +
        //     (transform.position - player.transform.position) + " " + dis);

        // if (dis < 1.0f)
        // {
        //     if (!stay)
        //     {
        //         stay = true;
        //         StartCoroutine(show());

        //     }
        // }
        //if(dis>2.5f)
        // {
        //     //if (stay)
        //     {
        //         StartCoroutine(fade());
        //         stay = false;
        //     }
        // }
        }
        if(pressed) StartCoroutine(fade());
        //Debug.Log(exit + " " + (float)canvas.alpha);
        if ((isCollide&&exit)&&canvas.alpha>0.0f)
        {
            StartCoroutine(fade());
        }
        
        //if (exit && canvas.alpha > 0.0f)
        //{
        //    Debug.Log("in");
        //    StartCoroutine(fade());
        //}
    }
    protected IEnumerator show()
    {
        //Debug.Log("show");
        float timeClip = 0.05f;
        for (int i = 0; i < 10; i++)
        {
            canvas.alpha += 0.1f;
            //Debug.Log(exit + " " + (float)canvas.alpha);
            yield return new WaitForSeconds(timeClip);
        }
        //isCollide = false;
        yield return true;
    }
    protected IEnumerator fade()
    {
        //Debug.Log("fade");
        float timeClip = 0.05f;
        float time = canvas.alpha / 0.1f;
        for (int i = 0; i <= time; i++)
        {
            if (canvas.alpha - 0.1f >= 0.0f) canvas.alpha -= 0.1f;
            else canvas.alpha = 0;
             yield return new WaitForSeconds(timeClip);
        }
        isCollide = false;
        yield return true;
    }
    //IEnumerator animation(string name,float oneTenthTime)
    //{
    //    animator.SetBool(name,true);
    //    for (int i = 0; i < 10; i++)
    //    {
    //        yield return new WaitForSeconds(oneTenthTime);
    //    }
    //    animator.SetBool(name, true);
    //}
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        exit = false;
    //        if (!isCollide/*&&!exit*/)
    //        {
    //            isCollide = true;
    //            StartCoroutine(show());
    //        }
    //    }
    //}
    private void OnTriggerStay(Collider other)
    {
        if (pressed) return;
        if (other.tag == "Player")
        {
            exit = false;
            if (!isCollide/*&&!exit*/)
            {
                isCollide = true;
                StartCoroutine(show());
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                pressed = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("triggerExit");
        if (other.tag == "Player")
        {
            exit = true;
            pressed = false;
            //if (!isCollide && !exit)
            //{
            //    StartCoroutine(show());
            //}

        }
    }
    //private void OnCollisionStay(Collision collision)
    //{
    //    if (collision.collider.tag == "Player")
    //    {
    //        exit = false;
    //        if (!isCollide/*&&!exit*/)
    //        {
    //            isCollide = true;
    //            StartCoroutine(show());
    //        }
    //        if (Input.GetKeyDown(KeyCode.Space))
    //        {
    //            pressed = true;
    //        }
    //    }
    //}
    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.collider.tag == "Player")
    //    {
    //        exit = true;
    //        //if (!isCollide && !exit)
    //        //{
    //        //    StartCoroutine(show());
    //        //}

    //    }
    //}
}
