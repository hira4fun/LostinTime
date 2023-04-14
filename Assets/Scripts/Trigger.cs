using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//to implement inheritance
public abstract class Trigger : MonoBehaviour
{
    //tags for the trigger
    public bool forceInteract;
    public bool repeatable;
    bool isActive;
    //only worry about this if it is not repeatable
    bool hasOccurred;
    public int value;

    public string playerTag = "Player"; //new variable for player tag

    // Start is called before the first frame update
    void Start()
    {
        hasOccurred = false;
    }

    //checks if player is in range of the trigger
    private void OnTriggerStay2D(Collider2D other) {
        if(other.CompareTag(playerTag)) {
            //Debug.Log("entered");
            isActive = true;
        }
        // else {
            
        //     isActive = false;
        //     Debug.Log("exit");
        
        //     if(forceInteract && repeatable) {
        //         hasOccurred = false;
        //     }
        // }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag(playerTag)) {
            isActive = false;
            //Debug.Log("exit");
        }
        if(forceInteract && repeatable) {
            hasOccurred = false;
        }
    }
    // Update is called once per frame
    public void Update()
    {
        // Debug.Log("testr");
        //checks if conditions are right
        if(isActive && !hasOccurred) 
        {
            //executes action upon entering
            if(forceInteract) 
            {
                Action();
                if(!repeatable) {
                    hasOccurred = true;
                    isActive = false;
                }
            }
            //only executes action if input is pressed
            else
            {
                if(Input.GetKeyDown(KeyCode.E)) {
                    //Debug.Log("action");
                    Action();
                    if(!repeatable)
                    {
                        hasOccurred = true;
                    }
                }
            }
        }
    }

    public abstract void Action();

}
