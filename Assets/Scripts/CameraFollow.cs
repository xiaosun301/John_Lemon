using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform roalTransform;
    Vector3 distence;
   

    void Start()
    {
        //roalTransform = GameObject.Find("JohnLemon").transform;
        // …Ë÷√≥ı ºæ‡¿Î
        distence = transform.position-roalTransform.position ;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = roalTransform.position + distence;
    }
}
