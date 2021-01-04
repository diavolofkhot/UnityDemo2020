using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Days : MonoBehaviour
{
    protected Text[] texts;
    public float dayNum;
    public float money;
    public float wage=300;
    public bool addOnce = false;
    public GameObject pay;
    protected bool waiting=false;
    public float rent = 4000;
    protected bool payed = false;
    // Start is called before the first frame update
    private void Awake()
    {
    }
    void Start()
    {
        texts = GetComponentsInChildren<Text>();
        //Debug.Log(texts.Length);
        dayNum = 1;
        money = 300;
        pay.SetActive(false);
    }
    public void initial()
    {
        //texts = GetComponentsInChildren<Text>();
        dayNum = 1;
        //Debug.Log("initial:"+dayNum);
        money = 300;
        //pay.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log("update");
        if (dayNum / 10 > 0 && dayNum % 10 == 0 && !payed)
        {
            pay.SetActive(true);
        }
        if (!(dayNum / 10 > 0 && dayNum % 10==0))payed = false;
        texts[3].text = dayNum.ToString();
        //Debug.Log("update:" + dayNum);
        texts[1].text = money.ToString();
        if(pay.activeSelf)texts[7].text = rent.ToString();
    }
    public void hidePay()
    {
        money -= rent;
        if (money >= 0)
        {
            pay.SetActive(false);
            payed = true;
        }
        else
        {
            SceneManager.LoadScene("End");
        }
    }
}
