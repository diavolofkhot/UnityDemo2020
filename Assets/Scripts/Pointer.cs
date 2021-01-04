using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pointer : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public string[] uiName;
    public bool pointAt = false;
    public GameObject canvas;
    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("pointerEnter");
        eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        //GraphicRaycaster gr = canvas.GetComponent<GraphicRaycaster>();
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        //gr.Raycast(eventData, results);
        if (results.Count != 0)
        {
            for (int i=0; i< uiName.Length; i++)
            {
                if (results[0].gameObject.name == uiName[i]/*"Fill"*/)
                {
                    pointAt = true;
                    //Debug.Log(results[0].gameObject.name);
                    return;
                }
                
                //return results[0].gameObject;
            }
        }
        //throw new System.NotImplementedException();
    }

    public void OnPointerExit(PointerEventData eventData)
    { 
        //Debug.Log("pointerExit");
        eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        //if (results.Count != 0)
        {
            //if (results[0].gameObject.name == "Fill")
            {
                pointAt = false;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (pointAt) canvas.SetActive(true);
        //else canvas.SetActive(false);
    }
}
