using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;



[RequireComponent(typeof(ARRaycastManager))]
public class PlaceObjects : MonoBehaviour
{
    // necessary components 
    private ARRaycastManager raycastManager;
    private GameObject spawnedObject;

    // placement indicator 
    public PlacementIndicator indicator;
    static List<ARRaycastHit> s_hits = new List<ARRaycastHit>();

    // object that contains the series of objects to place 
    public GameObject objectContainer;
    private int childIndex = 0;

    //game object to hold all placed objects 
    public GameObject collector;

    private void Awake()
    {
       
        raycastManager = GetComponent<ARRaycastManager>();
        
    }

    // check if the screen is being touched 
    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;
    }

    private void FixedUpdate()
    {
        s_hits = indicator.hits;
        if (!TryGetTouchPosition(out Vector2 touchPosition))
        {
            return;
        }
        // if screen is touched , get the finger that just touched the screen so objects dont spawn when your finger is on the screen 
        if (s_hits.Count >0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            var hitPos = s_hits[0].pose;
            
            spawnedObject = Instantiate(objectContainer.transform.GetChild(childIndex).gameObject, hitPos.position, hitPos.rotation);
            childIndex++;
            spawnedObject.transform.SetParent(collector.transform, true);
            spawnedObject = null;
        }
    }

}
