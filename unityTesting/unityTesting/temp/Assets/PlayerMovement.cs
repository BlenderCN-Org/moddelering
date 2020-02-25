using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform groundCheck;
    public float groundDistance = 500f;
    public LayerMask groundMask;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 1000f;

    private float x;
    private float z;
    private bool crouching = false;
    Vector3 velocity;
    bool isGrounded;

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }


        x = Input.GetAxis("Horizontal");      
        z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        SetAnimations();

        velocity.y += gravity * Time.deltaTime;
        // a = m/s^2
        controller.Move(velocity * Time.deltaTime);
    }

    private bool isCrouching = false;
    private void SetAnimations()
    {
        if (Input.GetButtonDown("Crouch"))
        {
            animator.SetBool("Crouch", true);

        }else if (Input.GetButtonUp("Crouch"))
        {
            animator.SetBool("Crouch", false);
        }
            animator.SetFloat("Speed", z);
    }
}
