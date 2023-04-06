using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCylinder : MonoBehaviour
{
    GameManager gameManager;
    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        StartCoroutine(selfRemoval());
    }

    IEnumerator selfRemoval()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            gameManager.UpdateCoins(1);
            Destroy(other.gameObject);
        }
    }

}
