using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{

    public string tagTarget = "Player";
    
    public SlimeDetection slimeDetection;

    public float moveSpeed = 1000f;

    Rigidbody2D rb;

    void FixedUpdate(){
        if(slimeDetection.detectedObjs.Count > 0){
            // Calculate direction to target object
            Vector2 direction = (slimeDetection.detectedObjs[0].transform.position - transform.position).normalized;

            // Move towards detected object
            rb.AddForce(direction * moveSpeed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.collider.tag == "Player"){
            Destroy(other.gameObject);
        }
    }
}
