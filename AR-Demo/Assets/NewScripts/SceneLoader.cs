using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    // parametre for saving camera and objects position and rotation 
    //public bool done= false;
    
    //ui components
    public TextMeshProUGUI startSearching;
    public Button transButton;

    // transition necessary components 
    public GameObject objectContainer;
    public GameObject collector;
    private float containerChild;
    private float collectorChild;
    // Start is called before the first frame update
    void Start()
    {
        // disable UI components like buttons to play the round 
        startSearching.enabled = false;
        transButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        containerChild = objectContainer.transform.childCount;
        collectorChild = collector.transform.childCount;
        

        if (containerChild == collectorChild)
        {
            // when objectContainer children objects are all placed , buttons are enabled 
            startSearching.enabled = true;
            transButton.gameObject.SetActive(true);
            //done = true;
        }
    }

}
