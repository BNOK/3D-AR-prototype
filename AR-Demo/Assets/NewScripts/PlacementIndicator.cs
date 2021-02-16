using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro;

public class PlacementIndicator : MonoBehaviour
{
    // text before the placement is ready 
    public TextMeshProUGUI waitingText;

    // raycasting components , the placement indicator object , the kist of hits of the raycast 
    private ARRaycastManager rayManager;
    private GameObject visual;
    public List<ARRaycastHit> hits = new List<ARRaycastHit>();
    void Start()
    {
        // get the components
        rayManager = FindObjectOfType<ARRaycastManager>();
        visual = transform.GetChild(0).gameObject;

        // hide the placement indicator visual
        visual.SetActive(false);
    }

    void Update()
    {
        // shoot a raycast from the center of the screen
       
        rayManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

        // if we hit an AR plane surface, update the position and rotation
        if (hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;

            // enable the visual if it's disabled
            if (!visual.activeInHierarchy)
            {
                visual.SetActive(true);
                waitingText.gameObject.SetActive(false);
            }
                

        }
    }
}