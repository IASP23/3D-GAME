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
        canJump = true;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {

        transform.Rotate(0, x * Time.deltaTime * rotationSpeed, 0);
        transform.Translate(0, 0, y * Time.deltaTime * runSpeed);

        animator.SetFloat("velX", x);
        animator.SetFloat("velY", y);
    }
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        if (canJump)
        {
            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }
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
        animator.SetBool("tocoSuelo", true);
    }

    void Cayendo()
    {
        Debug.Log("CAYE");
        animator.SetBool("tocoSuelo", false);
    }


}
