//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonEffects : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Text text;
    // Start is called before the first frame update
      void Start()
      {
        text = GetComponentInChildren<Text>();
      }

      // Update is called once per frame
      void Update()
      {

      }
      
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        text.transform.localScale = new Vector3(2/3f,2/3f,2/3f);
        text.fontSize = 40;
    }
    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
        text.transform.localScale = new Vector3(1f, 1f, 1f);
        text.fontSize = 30;
    }
    
}
