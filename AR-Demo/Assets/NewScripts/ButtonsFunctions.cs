using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;
public class ButtonsFunctions : MonoBehaviour
{
    
    // several functions for the buttons used in the UI 
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayAgain()
    {
        ARSession arSes = FindObjectOfType<ARSession>();
        Destroy(arSes.gameObject);
        ARSessionOrigin arCamera = FindObjectOfType<ARSessionOrigin>();
        Destroy(arCamera.gameObject);
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        ARSession arSes = FindObjectOfType<ARSession>();
        Destroy(arSes.gameObject);
        ARSessionOrigin arCamera = FindObjectOfType<ARSessionOrigin>();
        Destroy(arCamera.gameObject);
        SceneManager.LoadScene(0);
    }

    
}
