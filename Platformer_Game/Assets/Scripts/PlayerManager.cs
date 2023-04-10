using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{

    public class Player
    {
        public string name;
        public int powerUps;

        public Player(string n, int p)
        {
            name = n;
            powerUps = p;
        }

        public void UsePower()
        {
            powerUps--;
        }
    }

    private GameManager gameManager;
    public ParticleSystem attackPartical;
    public GameObject damageZone;

    private Animator animator;
    private MainMenuScript mainMenuScript;
    private PlayerMove playerMove;
    private bool isDamage;
    public GameObject textPressF;

    public Player player1 =  new Player("Player 1", 2);
   

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        animator = GetComponent<Animator>();
        mainMenuScript = GameObject.Find("UI").GetComponent<MainMenuScript>();
        isDamage = false;
        textPressF.SetActive(false);
        playerMove = GetComponent<PlayerMove>();
    }

    
    void Update()
    {
        makeDamage();
        PowerUp();
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


    private void makeDamage()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            attackPartical.Play();
            Instantiate(damageZone, transform.position, damageZone.transform.rotation);
            animator.SetTrigger("Jump_trig");

        }
    }

    private void PowerUp()
    {
        if (Input.GetKeyDown(KeyCode.Z) && player1.powerUps > 0)
        {
            player1.UsePower();
            playerMove.moveSpeed += 10;
        }
        
    }
    IEnumerator checkDamage()
    {
        isDamage = true;
        gameManager.UpdateLives(-1);
        mainMenuScript.TakeDamageUI();
        yield return new WaitForSeconds(1.5f);
        isDamage = false;
    }
}
