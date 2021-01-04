using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class donDestroy : MonoBehaviour
{
    public static donDestroy don;
    //public static donDestroy Instance { get { return don; } }
    public Days days;
    public GameObject uis;
    // Start is called before the first frame update
    private void Awake()
    {
        //Debug.Log("awakr");
        if (don != null)
        {
            //Debug.Log("don!=null");
            Destroy(/*this.gameObject*/don.gameObject);
            don= this;
            //don.uis.SetActive(true);
            return;
        }
        else
        {
            don = this;
        }
        
    }
    void Start()
    {
        don.days = GetComponentInChildren<Days>();
        don.days.initial();
        //don = this;
        don.uis.SetActive(true);
        //GameObject.DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(don);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
