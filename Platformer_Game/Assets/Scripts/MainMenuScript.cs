using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject pauseScreen;
    public GameObject takeDamage;

    private void Start()
    {
        gameOverScreen.SetActive(false);
        pauseScreen.SetActive(false);
    }


    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
   

    public void HomeMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ShowGameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
    }
    public void ÑontinueGame()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
    }
   
    public void TakeDamageUI()
    {
        StartCoroutine(ShowTimer(takeDamage));
        
    }

    IEnumerator ShowTimer(GameObject objectToShow)
    {
        objectToShow.SetActive(true);
        yield return new WaitForSeconds(2);
        objectToShow.SetActive(false);
    }
}
