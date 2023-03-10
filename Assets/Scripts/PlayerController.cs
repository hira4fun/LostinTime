using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

private class PlayerController : MonoBehaviour
{

    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;

    Vector2 movementInput;
    Rigidbody2D rb;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        // If movement input is not 0, try to move
        if(movementInput != Vector2.zero) {
            int count = rb.Cast(
                movementInput, // X and Y values between -1 and 1 represent the direction from the body to look for collisions
                movementFilter, // The settings that determine where a collision can occur on such layers to collide with
                castCollisions, // List of collisions to store the found collisions into after the Cast is finished
                moveSpeed * Time.fixedDeltaTime + collisionOffset); // The amount to cast equal to the movement plus an offset
            
            if(count == 0) {
                rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);
            }
        }
    }

    private void OnMove(InputValue movementValue) {
        movementInput = movementValue.Get<Vector2>();
    }
}
