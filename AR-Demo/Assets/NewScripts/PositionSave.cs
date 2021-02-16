using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSave : MonoBehaviour
{
    private SceneLoader doneVar;
    private GameObject arCamera;
    // Start is called before the first frame update
    void Start()
    {
        arCamera = this.transform.GetChild(0).gameObject;
        doneVar = FindObjectOfType<SceneLoader>();
        Debug.Log(arCamera.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (false)
        {
            // camera position saving 
            PlayerPrefs.SetFloat("x", arCamera.transform.position.x);
            PlayerPrefs.SetFloat("y", arCamera.transform.position.y);
            PlayerPrefs.SetFloat("z", arCamera.transform.position.z);
            PlayerPrefs.SetFloat("xrot", arCamera.transform.rotation.x);
            PlayerPrefs.SetFloat("yrot", arCamera.transform.rotation.y);
            PlayerPrefs.SetFloat("zrot", arCamera.transform.rotation.z);
            // object position saving 
        }

    }
}
