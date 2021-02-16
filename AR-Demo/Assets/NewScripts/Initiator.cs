using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using TMPro;

public class Initiator : MonoBehaviour
{
    //UI elements
    private GameObject distanceText;
    private GameObject objectsFound;

    //components
    private GameObject arCamera;
    private GameObject arSession;

    private GameObject playerCamera;
    // Start is called before the first frame update
    private void Awake()
    {
        arCamera = FindObjectOfType<ARSessionOrigin>().gameObject;
        arSession = FindObjectOfType<ARSession>().gameObject;

        arCamera.GetComponent<PlaceObjects>().enabled = false;
        playerCamera = arCamera.transform.GetChild(0).gameObject;
        playerCamera.GetComponent<DistanceToObject>().enabled = true;
        playerCamera.GetComponent<SelectObject>().enabled = true;
    }

    void Start()
    {
        
        //OK
       

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
