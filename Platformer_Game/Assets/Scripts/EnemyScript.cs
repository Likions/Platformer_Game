using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed;
    private Rigidbody rbEnemy;
    private GameObject player;
    private Animator animator;

    void Start()
    {
        rbEnemy = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(lookDirection,Vector3.up);

        rbEnemy.AddForce(lookDirection* speed);
        transform.rotation = rotation;
        animator.SetFloat("Speed_f", 1);
        
    }

  
}
