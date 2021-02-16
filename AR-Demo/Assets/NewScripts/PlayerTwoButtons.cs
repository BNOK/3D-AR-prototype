using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerTwoButtons : MonoBehaviour
{
    // player Two Buttons 
    public Button playAgain;
    public Button mainMenu;
    public TextMeshProUGUI roundText;

    // Start is called before the first frame update
    void Start()
    {
        playAgain.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
