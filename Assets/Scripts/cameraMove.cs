using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    public GameObject player;
    public GameObject camera_back;
    private Transform[] left;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
        left = camera_back.GetComponentsInChildren<Transform>();
        //for (int i = 0; i < 3; i++)
        //{
        //    Transform t = left[i];
        //    Debug.Log(t.name + t.position);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tmpTransform = player.transform.position + offset;
        if (tmpTransform.z < left[1].transform.position.z)
        {
            //transform.position = left[1].transform.position;
            tmpTransform.z = left[1].transform.position.z;
            transform.position = tmpTransform;
        }
        else if (tmpTransform.z > left[2].transform.position.z)
        {
            tmpTransform.z = left[2].transform.position.z;
            transform.position = tmpTransform;
            //transform.position = left[2].transform.position;
        }
        else transform.position = player.transform.position + offset;
    }
}
