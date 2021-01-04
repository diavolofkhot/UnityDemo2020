using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Animator envelope;
    public GameObject before;
    public GameObject after;
    public Animator titleAnimator;
    
    public GameObject[] texts;
    public float timeClip;
    //public GameObject black;
    // Start is called before the first frame update
    void Start()
    {
        timeClip = 0.1f;
        StartCoroutine("envelopeAnim");
        //StartCoroutine("titleAnim");
        for (int i = 0; i < texts.Length; i++) texts[i].SetActive(false);
        before.SetActive(true);
        after.SetActive(false);
    }
    IEnumerator envelopeAnim()
    {
        envelope.SetBool("show", true);
        for (int i = 0; i < 1; i++) yield return new WaitForSeconds(timeClip);
        envelope.SetBool("show", false);
        //
        for (int i = 0; i < 1; i++) yield return new WaitForSeconds(timeClip);
        //
        titleAnimator.SetBool("show", true);
        for (int i = 0; i < 1; i++) yield return new WaitForSeconds(timeClip);
        titleAnimator.SetBool("show", false);
        //
        for (int i = 0; i < 35; i++) yield return new WaitForSeconds(timeClip);
        //StartCoroutine("titleAnim");
        StartCoroutine("envelopeAnim");
    }
    IEnumerator toGame()
    {
        before.SetActive(false);
        //black.SetActive(true);
        after.SetActive(true);
        for (int i = 0; i < texts.Length; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                yield return new WaitForSeconds(timeClip);
            }
            texts[i].SetActive(true);
        }
        for (int j = 0; j < 20; j++)
        {
            yield return new WaitForSeconds(timeClip);
        }
        SceneManager.LoadScene("Game");
    }
    public void loadGame()
    {
        StartCoroutine(toGame());
    }
    //IEnumerator titleAnim()
    //{
    public void exit()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
        
    //}
    // Update is called once per frame
    void Update()
    {
        
    }
}
