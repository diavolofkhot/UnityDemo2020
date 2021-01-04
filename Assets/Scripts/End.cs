using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    //public GameObject screen;
    public GameObject beginAgain;
    public GameObject back;
    public GameObject[] screenTexts;
    public CanvasGroup black;
    // Start is called before the first frame update
    void Start()
    {
        black.alpha = 1;
        donDestroy.don.uis.SetActive(false);
        Text num=screenTexts[1].GetComponentInChildren<Text>();
        num.text = donDestroy.don.days.dayNum.ToString();
        //screenTexts = screen.GetComponentsInChildren<Text>();
        for (int i = 0; i < screenTexts.Length; i++)
        {
            screenTexts[i].SetActive(false);
        }
        beginAgain.SetActive(false);
        back.SetActive(false);
    StartCoroutine("end");
    }
    IEnumerator end()
    {
        float timeClip = 0.05f;
        for (int j = 0; j < 20; j++)
        {
            black.alpha -=timeClip;
            yield return new WaitForSeconds(timeClip);
        }
        timeClip = 0.1f;
        for (int i = 0; i < screenTexts.Length; i++)
        {
            for (int j = 0; j <8;j++)
            {
                yield return new WaitForSeconds(timeClip);
            }
            screenTexts[i].SetActive(true);
        }
        for (int j = 0; j < 15; j++)
        {
            yield return new WaitForSeconds(timeClip);
        }
        beginAgain.SetActive(true);
        back.SetActive(true);
    }
    public void toMenu()
    {
        //Debug.Log("toMenu");
        SceneManager.LoadScene("Menu");
    }
    public void loadGameAgain()
    {
        SceneManager.LoadScene("Game");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {
        //Debug.Log("destroy");
        Destroy(donDestroy.don);
    }
}
