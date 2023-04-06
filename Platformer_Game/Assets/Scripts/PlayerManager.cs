using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    private GameManager gameManager;
    public ParticleSystem attackPartical;
    public GameObject damageZone;

    private Animator animator;
    private MainMenuScript mainMenuScript;

    private bool isDamage;
    public GameObject textPressF;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        animator = GetComponent<Animator>();
        mainMenuScript = GameObject.Find("UI").GetComponent<MainMenuScript>();
        isDamage = false;
        textPressF.SetActive(false);
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            attackPartical.Play();
            Instantiate(damageZone,transform.position,damageZone.transform.rotation);
            animator.SetTrigger("Jump_trig");

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Obsticale":
                if (isDamage == false)
                {
                    StartCoroutine(checkDamage());
                }       
                break;
            case "Enemy":
                if (isDamage == false)
                {
                    StartCoroutine(checkDamage());
                }
                break;
            case "Coins":
                gameManager.UpdateCoins(1);
                Destroy(other.gameObject);
                break;
            case "Interactive":
                textPressF.SetActive(true);
                break;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Interactive")
        {
            textPressF.SetActive(false);
        }
    }



    IEnumerator checkDamage()
    {
        isDamage = true;
        gameManager.UpdateLives(-1);
        mainMenuScript.TakeDamage();
        yield return new WaitForSeconds(1.5f);
        isDamage = false;
    }
}
