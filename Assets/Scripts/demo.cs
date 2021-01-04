using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demo : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("u1");
        if (collision.collider.tag == "Player")
        {
            Debug.Log("u2");
            collision.collider.transform.position = transform.position;
        }
    }
    
}
