using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed;
    public float jumpSpeed;

    public float ySpeed;
    

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    private Animator animator;
    private Rigidbody rb;
    private CharacterController characterController;
    private Camera cam;

    private void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        cam = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();    
    }

    public void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 moveInput = new Vector3(h, 0, v);
        float magnitude = Mathf.Clamp01(moveInput.magnitude) * moveSpeed;
        moveInput.Normalize();

        ySpeed += (Physics.gravity.y * Time.deltaTime);

        if (characterController.isGrounded)
        {
            ySpeed = -0.5f;

            if (Input.GetButtonDown("Jump"))
            {
                Jump(jumpSpeed);
            }
        }
     
        Vector3 velocity = moveInput * magnitude;
        velocity.y = ySpeed;

        characterController.Move(velocity * Time.deltaTime);


        if (moveInput != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveInput, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            animator.SetFloat("Speed_f", 1);
        }
        else
        {
            animator.SetFloat("Speed_f", 0);
        }
    }
    public void Jump(float jumpSpeed)
    {
        ySpeed = jumpSpeed;
    }

}
