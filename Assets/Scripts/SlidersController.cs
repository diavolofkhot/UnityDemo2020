using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidersController : MonoBehaviour
{
    public float left=25,top=25;
    public float eachHeight=0.3f;
    public int childrenNum = 5;
    //public Vector2[] anchor0=new Vector2[2];
    public Vector2 anchorMin = new Vector2(0.0f,0.7f);
    public Vector2 anchorMax = new Vector2(0.27f,1.0f);
    private RectTransform[] slidersRect;
    private float gap;
    // Start is called before the first frame update
    void Start()
    {
        slidersRect = GetComponentsInChildren<RectTransform>();
        changeSlidersPos();
    }
    void changeSlidersPos()
    {
        Vector2 offMin = new Vector2(left, 0), offMax = new Vector2(0, -top);
        slidersRect[0].offsetMin = offMin;
        slidersRect[0].offsetMax = offMax;
        slidersRect[0].anchorMin = anchorMin;// anchor0[0];
        slidersRect[0].anchorMax = anchorMax;// anchor0[1];
        Vector2 min = new Vector2(0.0f, 0.0f), max = new Vector2(1, 0);
        int len = ((slidersRect.Length - 1) / childrenNum);
        gap = (1 - (eachHeight * len)) / (len - 1);
        //Debug.Log(slidersRect.Length+"gap" + gap+" "+len);
        len = (len - 1) * childrenNum + 1;
        for (int i = len; i > 0; i -= childrenNum)
        {
            max.y += eachHeight;
            if (max.y > 1) max.y = 1;
            //Debug.Log(i + " " + min.y + " " + max.y);
            slidersRect[i].anchorMin = min;
            slidersRect[i].anchorMax = max;
            max.y += gap;
            min.y = max.y;
        }
    }
    // Update is called once per frame
    void Update()
    {
        changeSlidersPos();
    }
}
