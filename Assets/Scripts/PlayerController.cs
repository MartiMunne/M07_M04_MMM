using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float range = 1.1f;
    private Vector3 offset = new Vector3(0, 1f, 0);
    private Animator animator;
    private bool isGrounded;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position + offset, -Vector3.up);
        Debug.DrawLine(transform.position + offset, transform.position + offset - Vector3.up * range, Color.red);

        // Comprobaciçon IsGrounded
        if (Physics.Raycast(ray, out hit, range))
        {
            if (hit.collider.gameObject.layer == 7)
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }
        }
        else
        {
            isGrounded = false;
        }
        if(isGrounded)
        {
            animator.SetBool("isGrounded", true);
        }
        else
        {
            animator.SetBool("isGrounded", false);
        }

        //Condición para correr
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
        //Condición para saltar
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            animator.SetBool("isJumping", true);
        }
        else
        {
            animator.SetBool("isJumping", false);
        }
    }
}
