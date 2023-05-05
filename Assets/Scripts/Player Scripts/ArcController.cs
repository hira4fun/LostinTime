using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Takes and handles input and movement for a player character
public class ArcController : MonoBehaviour
{
    public static ArcController instance;
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    public WhipAttack whipAttack;
    public GameObject myGameObject;
    public static bool pause = false;
    Vector2 movementInput;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    Animator animator;
    float xMove;
    float yMove;
    public static float health = 4;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    public GameObject endScreen;

    bool canMove = true;

    public float faceDir = 2;
    /*
    1 = North
    2 = South
    3 = East
    4 = West
    */

    private void Awake(){
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        pause = false;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void toggleWhipBox() {
        //toggles the whip hitbox
        myGameObject.SetActive(!myGameObject.activeSelf);
    }

    void Update() {
        //activates whip hitbox for half a second, then deactivates it
        if (Input.GetKeyDown(KeyCode.Space)) {
            whipAttack.Attack();
            toggleWhipBox();
            Invoke("toggleWhipBox", 0.5f);
        }
    }

    private void FixedUpdate() {
        if(canMove) {
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
            // Sets facing direction to north
            if(movementInput.y > 0) {
                faceDir = 1;
            }
            // Sets facing direction to south
            if(movementInput.y < 0) {
                faceDir = 2;
            }
            // Sets facing direction to east
            if(movementInput.x > 0) {
                faceDir = 3;
            }
            // Sets facing direction to west
            if(movementInput.x < 0) {
                faceDir = 4;
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
        animator.SetTrigger("whipAttack");
    }
   
    public void WhipAttack() {
        //LockMovement();
    }
    
    public void EndWhipAttack() {
        //UnlockMovement();
        whipAttack.StopAttack();
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

    public float Health {
        set {
            health = value;
            GameObject healthDisplay = GameObject.Find("HealthDisplay");
            if (healthDisplay != null)
            {
                healthDisplay.GetComponent<HealthDisplay>().SetLastChangedScript("ArcController");
            }
            if (health <= 0) {
                Defeated();
            }
        }
        get {
            return health;
        }
    }

    public void Defeated() {
        RemovePlayer();
    }

    private void RemovePlayer() {
        pause = true;
        endScreen.SetActive(true);
    }
}