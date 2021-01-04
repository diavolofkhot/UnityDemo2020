using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIpointer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public BarsController barsController;
    private string oldName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("pointerEnter");
        eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        //GraphicRaycaster gr = canvas.GetComponent<GraphicRaycaster>();
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        //gr.Raycast(eventData, results);
        Debug.Log(results.Count);
        if (results.Count > 0)
        {
            Debug.Log("0:"+results[0].gameObject.name + " 1:" + results[1].gameObject.name);
            if (results[1].gameObject.name == "hungerFill")
            {
                barsController.pointers[0].pointAt = true;
                oldName = "hungerFill";
            }
            else if (results[1].gameObject.name == "cleanFill")
            {
                barsController.pointers[1].pointAt = true;
                oldName = "cleanFill";
            }

            //return results[0].gameObject;
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
            Debug.Log(oldName);
            //if (results[0].gameObject.name == "Fill")
            if (oldName == "hungerFill")
            {
                barsController.pointers[0].pointAt = true;
                oldName = "";
            }
            else if (oldName == "cleanFill")
            {
                barsController.pointers[0].pointAt = true;
                oldName = "";
            }
        }
    }
}
