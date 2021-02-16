using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.XR.ARFoundation;

public class PlayerOneTimer : MonoBehaviour
{
    // objects to save and not destroy 
    public GameObject arSession;
    public GameObject arSessionOrigin;
    
    //Player One Object placed 
    public GameObject collector;
    public TextMeshProUGUI objectsPlaced;
    //Player One Timer
    public TextMeshProUGUI timerText;
    private float roundTime =90f;
    // Start is called before the first frame update
    void Awake()
    {
         ARSession[] arCamera = FindObjectsOfType<ARSession>();
        ARSessionOrigin[] arSesOrig = FindObjectsOfType<ARSessionOrigin>();

        if ( arCamera.Length > 1)
        {
           // Destroy(arCamera[1].gameObject);
        }
        if(arSesOrig.Length > 1)
        {
           // Destroy(arSesOrig[1].gameObject);
        }
    
        // parent object that contains children 
        DontDestroyOnLoad(collector);
        DontDestroyOnLoad(arSession);
        DontDestroyOnLoad(arSessionOrigin);

    }

    // Update is called once per frame
    void Update()
    {
        // updating the roundtimer 
        roundTime -= Time.deltaTime;
        timerText.text = roundTime.ToString("F0");
        
        // updating objects found 
        objectsPlaced.text = collector.transform.childCount.ToString() + "/4";

        if (roundTime <= 0 && collector.transform.childCount !=4)
        {
            SceneManager.LoadScene(0);
        }
    }
}
