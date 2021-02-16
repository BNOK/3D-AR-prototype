using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateChildren : MonoBehaviour
{

    private GameObject parentObject;
    // Start is called before the first frame update
    void Start()
    {
        parentObject = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i =0; i<parentObject.transform.childCount; i++)
        {
            parentObject.transform.GetChild(i).gameObject.transform.Rotate(new Vector3(0, 30 * Time.deltaTime, 0));
        }
    }
}
