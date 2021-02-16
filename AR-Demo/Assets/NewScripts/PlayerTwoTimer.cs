using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerTwoTimer : MonoBehaviour
{
    // necessary scripts 
    private SelectObject findingScript;
    private DistanceToObject objectDistance;
    // ar camera
    private GameObject arCamera;
    // Player Two Timer 
    public TextMeshProUGUI timerText;
    private float roundTimer =120f;

    // Player Two object Founder
    public GameObject collector;
    public SelectObject blackList;
    

    // player Two Buttons 
    public Button playAgain;
    public Button mainMenu;
    public TextMeshProUGUI roundText;


    // Start is called before the first frame update
    private void Awake()
    {
        arCamera = FindObjectOfType<Camera>().gameObject;
        findingScript = FindObjectOfType<SelectObject>();
        objectDistance = FindObjectOfType<DistanceToObject>();
        // enabling the scripts if any are not checked
        findingScript.enabled = true;
        objectDistance.enabled = true;
    }
    void Start()
    {
        
        
        //defining the blacklist that will be filled with the selected items 
        blackList = FindObjectOfType<SelectObject>();
        // defining the collector that contains the objects , timer text component , play again and main menu buttons 
        collector = FindObjectOfType<RotateChildren>().gameObject;
        timerText.text = roundTimer.ToString("F0");
        playAgain.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(roundTimer >= 0 && collector.transform.childCount != blackList.objectBlacklist.Count)
        {
            roundTimer -= Time.deltaTime;
            timerText.text = roundTimer.ToString("F0");
        }
        else 
        {
            playAgain.gameObject.SetActive(true);
            mainMenu.gameObject.SetActive(true);
            if (collector.transform.childCount == blackList.objectBlacklist.Count)
            {
                roundText.text = " VICTORY";
                roundText.color = Color.yellow;
            }
            else if (collector.transform.childCount != blackList.objectBlacklist.Count)
            {
                roundText .text = "ROUND LOST ";
                roundText.color = Color.red;
            }
        }


    }
}
