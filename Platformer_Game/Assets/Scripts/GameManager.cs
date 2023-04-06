using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private MainMenuScript menuScript;

    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI livesText;
    private int coins;
    private int lives;

    public GameObject activePortal;

    // Start is called before the first frame update
    void Start()
    { 
        menuScript = GameObject.Find("UI").GetComponent<MainMenuScript>();
        UpdateLives(3);
        activePortal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCoins(int coinsToAdd)
    {
        coins += coinsToAdd;
        coinsText.text = "Coins: " + coins;
        
        if (coins >= 10)
        {
            activePortal.SetActive(true);
        } 
    }
    public void UpdateLives(int livesToAdd)
    {
        lives += livesToAdd;
        livesText.text = "Lives: " + lives;
        
        if (lives <= 0)
        {
            menuScript.ShowGameOver();
        }
    }
}
