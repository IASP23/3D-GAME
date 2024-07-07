using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float runSpeed = 7;
    public float rotationSpeed = 250;
    public float jumpForce = 6;  // Fuerza del salto
    public Animator animator;
    public Rigidbody rb;  // Referencia al Rigidbody

    private float x, y;
    public bool canJump;

    void Start()
    {
        canJump = false;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {

        transform.Rotate(0, x * Time.deltaTime * rotationSpeed, 0);
        transform.Translate(0, 0, y * Time.deltaTime * runSpeed);


    }
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        animator.SetFloat("velX", x);
        animator.SetFloat("velY", y);

        if (canJump)
        {
            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }
            animator.SetBool("tocoSuelo", true);
        }
        else
        {
            Cayendo();
        }
    }

    void Jump()
    {
        rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        animator.SetBool("salte", true);
    }

    void Cayendo()
    {
        animator.SetBool("tocoSuelo", false);
        animator.SetBool("salte", false);
    }


}
