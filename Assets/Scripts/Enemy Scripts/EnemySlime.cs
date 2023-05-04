using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlime : MonoBehaviour
{

    public SlimeDetection slimeDetection;
    public float moveSpeed = 500f;
    // public float damage = 1;
    public float knockbackForce = 300f;
    Rigidbody2D rb;

    void FixedUpdate(){
        if(slimeDetection.detectedObjs.Count > 0){
            // Calculate direction to target object
            Vector2 direction = (slimeDetection.detectedObjs[0].transform.position - transform.position).normalized;

            // Move towards detected object
            rb.AddForce(direction * moveSpeed * Time.deltaTime);
        }
    }

    // Damages players
    void OnTriggerEnter2D(Collider2D other){
        /*
        if(other.gameObject.tag == "Player"){
            // Damages architect
            ArcController arcController = other.GetComponent<ArcController>();
            if(arcController != null) {
                arcController.Health -= damage;
            }
        }
        */
        if(other.tag == ("PlayerAttack")){
            Vector2 difference = transform.position - other.transform.position;
            transform.position = new Vector2(transform.position.x + difference.x, transform.position.y + difference.y);
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

    public float health = 3;

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