using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Animator animator;
    private Rigidbody2D rb;
    public static bool pause = false;
    public Transform charArtTransform;



    private void Awake()
    {
         pause = false; 
         rb = GetComponent<Rigidbody2D>();
         charArtTransform = transform.Find("CharArt");

    }

    private void Update()
    {
        if (!pause)

        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector2 movement = new Vector2(horizontalInput, verticalInput);
            rb.velocity = movement * moveSpeed;
            animator.SetFloat("Speed", rb.velocity.magnitude);
            if (horizontalInput < 0)
            {
                charArtTransform.localScale = new Vector3(-1, 1, 1);
            }
            else if (horizontalInput > 0)
            {
                charArtTransform.localScale = new Vector3(1, 1, 1);

            }
        }
        if (pause)
        {
            rb.velocity = Vector2.zero;

        }

    }
}
