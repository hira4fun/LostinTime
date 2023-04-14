using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Takes and handles input and movement for a player character
public class WizController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    public MagicAttack magicAttack;
    public GameObject myGameObject;
    public static bool pause = false;


    Vector2 movementInput;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    Animator animator;
    float xMove;
    float yMove;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void toggleMagicBox() {
        //toggles the magic hitbox
        myGameObject.SetActive(!myGameObject.activeSelf);
    }

    void Update() {
        //activates magic hitbox for a second, then deactivates it
        if (Input.GetKeyDown(KeyCode.Space)) {
            toggleMagicBox();
            Invoke("toggleMagicBox", 0.7f);
        }
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            if (!pause)

            {
                // If movement input is not 0, try to move
                if (movementInput != Vector2.zero)
                {

                    bool success = TryMove(movementInput);

                    if (!success)
                    {
                        success = TryMove(new Vector2(movementInput.x, 0));
                    }

                    if (!success)
                    {
                        success = TryMove(new Vector2(0, movementInput.y));
                    }
                    animator.SetFloat("Xinput", xMove);
                    animator.SetFloat("Yinput", yMove);
                    animator.SetBool("isMoving", success);
                }
                else
                {
                    animator.SetBool("isMoving", false);
                }
            }
            if (pause)
            {
                rb.velocity = Vector2.zero;

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
        xMove = movementInput.x;
        yMove = movementInput.y;
    }

    void OnFire() {
        animator.SetTrigger("magicAttack");
    }

    public void MagicAttack() {
        //LockMovement();

        if(spriteRenderer.flipX == true){
            magicAttack.AttackLeft();
        } else {
            magicAttack.AttackRight();
        }
    }

    public void EndMagicAttack() {
        //UnlockMovement();
        magicAttack.StopAttack();
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
