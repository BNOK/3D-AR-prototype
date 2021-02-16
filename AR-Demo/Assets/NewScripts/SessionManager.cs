using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class SessionManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        ARSession[] arSes = FindObjectsOfType<ARSession>();
        ARSessionOrigin[] arCamera = FindObjectsOfType<ARSessionOrigin>();

        if (arSes.Length > 1)
        {
            //arSes[0].gameObject.SetActive(false);
        }
        if(arCamera.Length > 1)
        {
            //arCamera[0].gameObject.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
