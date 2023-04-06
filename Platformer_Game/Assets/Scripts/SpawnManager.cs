using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;
    private GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnEnemy()
    {
        float spawnPosX = Random.Range(player.transform.position.x + 20, player.transform.position.x + 50);
        float spawnPosZ = Random.Range(1, 19);
        Vector3 spawnPos = new Vector3(spawnPosX, 0, spawnPosZ);
        Instantiate(enemy, spawnPos, enemy.transform.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            for (int i = 0; i <3; i++)
            {
                SpawnEnemy();
            }
           Destroy(gameObject);
        }
    }
}
