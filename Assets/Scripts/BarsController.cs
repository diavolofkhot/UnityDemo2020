using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BarsController :MonoBehaviour/*,IPointerDownHandler,IPointerEnterHandler*/
{
    public GameObject slider;
    public float hungerDecline = 0.01f;
    public float cleanDecline = 0.01f;
    public float tiredDecline = 0.01f;
    public Slider[] bars;
    private Text[] showNumber;
    public Pointer[] pointers;
    private bool isChanging = false;
    public float timeClip = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        bars = slider.GetComponentsInChildren<Slider>();
        showNumber= slider.GetComponentsInChildren<Text>();
        pointers = slider.GetComponentsInChildren<Pointer>();
        for (int i = 0; i < bars.Length; i++)
        {
            bars[i].value = 1;
        }
        for (int i = 1; i <= showNumber.Length; i+=2)
        {
            showNumber[i].gameObject.SetActive(false);
        }
    }
    IEnumerator changeValue()
    {
        //Debug.Log("barsChangeValue");
        isChanging = true;
        {
            if (bars[0].value - hungerDecline < 0) bars[0].value = 0;
            else  bars[0].value -= hungerDecline /** Time.deltaTime*/;
            //string tmp = (bars[0].value * 100).ToString("0.0");
            //tmp += "/100";
            //showNumber[1].text = tmp;
            //Debug.Log(hungerDecline * Time.deltaTime + " " + bars[0].value);
            //
            if (bars[1].value - cleanDecline < 0) bars[1].value = 0;
            else
                bars[1].value -= cleanDecline /** Time.deltaTime*/;
            //tmp = (bars[1].value * 100).ToString("0.0");
            //tmp += "/100";
            //showNumber[3].text = tmp;
            //
            //bars[2].value -= tiredDecline * Time.deltaTime;
            //tmp = (bars[2].value * 100).ToString("0.0");
            //tmp += "/100";
            //showNumber[5].text = tmp;
        }
        
        for (int i=0;i< 10; i++) yield return new WaitForSeconds(timeClip);
        
        isChanging = false;
    }
    //public GameObject GetOverUI(GameObject canvas)
    //{
    //    PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
    //    pointerEventData.position = Input.mousePosition;
    //    GraphicRaycaster gr = canvas.GetComponent<GraphicRaycaster>();
    //    List<RaycastResult> results = new List<RaycastResult>();
    //    gr.Raycast(pointerEventData, results);
    //    if (results.Count != 0)
    //    {
    //        return results[0].gameObject;
    //    }

    //    return null;
    //}
    // Update is called once per frame
    void Update()
    {
        if (!isChanging) StartCoroutine(changeValue());
        showNumber[1].gameObject.SetActive(pointers[0].pointAt);
        showNumber[3].gameObject.SetActive(pointers[1].pointAt);
        //showNumber[5].gameObject.SetActive(pointers[2].pointAt);
        string tmp = (bars[0].value * 100).ToString("0.0");
        tmp += "/100";
        showNumber[1].text = tmp;
        //
        tmp = (bars[1].value * 100).ToString("0.0");
        tmp += "/100";
        showNumber[3].text = tmp;
    }
    
}
