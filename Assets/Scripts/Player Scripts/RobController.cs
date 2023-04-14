using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Takes and handles input and movement for a player character
public class RobController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    public GunAttack gunAttack;
    public GameObject myGameObject;

    Vector2 movementInput;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    Animator animator;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void toggleGunBox() {
        //toggles the gun hitbox
        myGameObject.SetActive(!myGameObject.activeSelf);
    }

    void Update() {
        //activates gun hitbox several times rapidfire
        if (Input.GetKeyDown(KeyCode.Space)) {
            Invoke("toggleGunBox", 0.05f);
            Invoke("toggleGunBox", 0.1f);
            Invoke("toggleGunBox", 0.15f);
            Invoke("toggleGunBox", 0.2f);
            Invoke("toggleGunBox", 0.25f);
            Invoke("toggleGunBox", 0.3f);
            Invoke("toggleGunBox", 0.35f);
            Invoke("toggleGunBox", 0.4f);
            Invoke("toggleGunBox", 0.45f);
            Invoke("toggleGunBox", 0.5f);
            Invoke("toggleGunBox", 0.55f);
            Invoke("toggleGunBox", 0.6f);
            Invoke("toggleGunBox", 0.65f);
            Invoke("toggleGunBox", 0.7f);
            Invoke("toggleGunBox", 0.75f);
            Invoke("toggleGunBox", 0.8f);
        }
    }

    private void FixedUpdate() {
        if(canMove) {
            // If movement input is not 0, try to move
            if(movementInput != Vector2.zero){
                
                bool success = TryMove(movementInput);

                if(!success) {
                    success = TryMove(new Vector2(movementInput.x, 0));
                }

                if(!success) {
                    success = TryMove(new Vector2(0, movementInput.y));
                }
                
                animator.SetBool("isMoving", success);
            } else {
                animator.SetBool("isMoving", false);
            }
        }
    }

    private bool TryMove(Vector2 direction) {
        if(direction != Vector2.zero) {
            // Check for potential collisions
            int count = rb.Cast(
                direction, // X and Y values between -1 and 1 that represent the direction from the body to look for collisions
                movementFilter, // The settings that determine where a collision can occur on such as layers to collide with
                castCollisions, // List of collisions to store the found collisions into after the Cast is finished
                moveSpeed * Time.fixedDeltaTime + collisionOffset); // The amount to cast equal to the movement plus an offset

            if(count == 0){
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
                return true;
            } else {
                return false;
            }
        } else {
            // Can't move if there's no direction to move in
            return false;
        }
        
    }

    void OnMove(InputValue movementValue) {
        movementInput = movementValue.Get<Vector2>();
    }

    void OnFire() {
        animator.SetTrigger("gunAttack");
    }

    public void GunAttack() {
        //LockMovement();

        if(spriteRenderer.flipX == true){
            gunAttack.AttackLeft();
        } else {
            gunAttack.AttackRight();
        }
    }

    public void EndGunAttack() {
        //UnlockMovement();
        gunAttack.StopAttack();
        //movementInput = Vector2.zero; // re-enable movement input
    }

    /*
    public void LockMovement() {
        canMove = false;
        movementInput = Vector2.zero; // disable movement input
    }

    public void UnlockMovement() {
        canMove = true;
    }
    */
}
