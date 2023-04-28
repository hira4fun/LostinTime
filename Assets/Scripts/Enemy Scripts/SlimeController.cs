using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{
    public SlimeDetection slimeDetection;

    public float moveSpeed = 1000f;

    Rigidbody2D rb;

    public Collider2D col;

    void FixedUpdate(){
        if(slimeDetection.detectedObjs.Count > 0){
            // Calculate direction to target object
            Vector2 direction = (slimeDetection.detectedObjs[0].transform.position - transform.position).normalized;

            // Move towards detected object
            rb.AddForce(direction * moveSpeed * Time.deltaTime);
        }
    }

    void OnColliderEnter2D(Collider2D col){
        if(collider.gameObject.tag == "Player"){      
            Debug.Log("Colliding with player");
        }
    }
}
