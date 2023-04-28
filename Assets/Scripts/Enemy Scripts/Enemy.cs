using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

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

    public float Health {
        set {
            health = value;

            if (health <= 0) {
                Defeated();
            }
        }
        get {
            return health;
        }
    }

    public float health = 1;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Defeated() {
        RemoveEnemy();
    }

    private void RemoveEnemy() {
        Destroy(gameObject);
    }
}