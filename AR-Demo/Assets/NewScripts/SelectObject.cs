using System.Collections;
using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class SelectObject : MonoBehaviour
{ 
    // raycast variables 
    
    public RaycastHit hits = new RaycastHit();
    public List<GameObject> objectBlacklist = new List<GameObject>();

    // Finding Components 
    public TextMeshProUGUI objectsFound;
    public int FoundIndex ;
    private Animator objectAnimator;

    // Finding Process
    private GameObject collector;

    // Start is called before the first frame update
    private void Awake()
    {
        collector = FindObjectOfType<RotateChildren>().gameObject;
        
    }
    void Start()
    {
        objectsFound = GameObject.FindGameObjectWithTag("ObjectFoundTag").GetComponent<TextMeshProUGUI>();

        FoundIndex = collector.transform.childCount ;
        objectsFound.text = "4/4";

        // disable all children of collector 
        for (int i = 0; i < collector.transform.childCount; i++)
        {
            collector.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

   

    // Update is called once per frame

    // the foundindex goes from 0 to number of children 
    void Update()
    {
        // caution loop so index dont get out of bounds 
        if (FoundIndex <= 0)
        {
            FoundIndex = 0;
        }

        // enable the object with foundindex
        collector.transform.GetChild(FoundIndex - 1).gameObject.SetActive(true);
        // testing logs 
        Debug.DrawRay(transform.position, transform.forward * 10, Color.yellow);
        Debug.Log("LIST SIZE IS " +objectBlacklist.Count);
        Debug.Log("FoundIndex is " + FoundIndex);
        Debug.Log("collector children" + collector.transform.childCount);

        // raycast to shoot the object 
        if ( Physics.Raycast(transform.position, transform.forward, out RaycastHit hits) )
        {
            // go is the object hit 
            GameObject go = hits.collider.gameObject;

            // check if the object is in the blacklist to do the things inside the loop 
            if (!BlackListed(go))
            {
                Debug.Log("inside the second IF !");
                objectBlacklist.Add(go);
                StartCoroutine(FindingObject(go));
                objectsFound.text = FoundIndex -1 + "/4";
                FoundIndex--;
                
            }
                        
        }
    }

     private bool BlackListed(GameObject objectInput)
    {
        if (objectBlacklist.Count != 0)
        {
            foreach (var lObject in objectBlacklist)
            {
                if (objectInput == lObject)
                {
                    return true;
                }
            }
        }
        
        return false;
    }

    // start animation of the found object 
    private IEnumerator FindingObject(GameObject go)
    {
        objectAnimator = go.GetComponent<Animator>() ;
        objectAnimator.SetTrigger("Start");
        yield return new WaitForSeconds(1.0f);
        
    }

}
