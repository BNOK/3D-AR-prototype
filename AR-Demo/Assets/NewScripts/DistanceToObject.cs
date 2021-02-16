using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanceToObject : MonoBehaviour
{
    
    //object to track  
    public GameObject targetObject;
    private GameObject collector;
    private int childIndex;
    
    // text that descriobes the distance 
    public TextMeshProUGUI distanceText;

    // Start is called before the first frame update

    private void Awake()
    {
        collector = FindObjectOfType<RotateChildren>().gameObject;

    }

    void Start()
    {
        distanceText = GameObject.FindGameObjectWithTag("DistanceTag").GetComponent<TextMeshProUGUI>();
        childIndex = FindObjectOfType<SelectObject>().FoundIndex;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        targetObject = collector.transform.GetChild(childIndex).gameObject;
        FindingProcess(targetObject);
    }


    // change distance text through calculating distance between the camera and the game object 
    private void FindingProcess(GameObject targetObject)
    {
        float distance = Vector3.Distance(this.transform.position, targetObject.transform.position);
        
        if (distance >= 3.0f)
        {
            
            distanceText.text = "COLD";
            distanceText.color = Color.blue ;
            
        }
        else if (distance <= 2.0f)
        {
            distanceText.text = "HOT";
            distanceText.color = Color.red;
            
        }
        else
        {
            distanceText.text = "WARM";
            distanceText.color = Color.green;
            
        }

    }
}
