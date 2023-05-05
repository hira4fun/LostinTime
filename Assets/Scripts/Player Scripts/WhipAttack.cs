using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipAttack : MonoBehaviour
{
    public Collider2D whipCollider;
    public float damage = 3;
    Animator animator;

    void Start(){
        animator = GetComponent<Animator>();
    }

    void Update(){
        if(whipCollider.enabled == true){
            animator.SetTrigger("whipAtk");
        } else {
            animator.SetTrigger("whipAtk");
        }
    }

    public void Attack() {
        whipCollider.enabled = true;
    }

    public void StopAttack() {
        whipCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy") {
            // Deal damage to the enemy
            Enemy enemy = other.GetComponent<Enemy>();
            EnemySlime enemySlime = other.GetComponent<EnemySlime>();

            if(enemy != null) {
                enemy.Health -= damage;
            }
            if(enemySlime != null) {
                enemySlime.Health -= damage;
                Debug.Log("damage to slime");
            }
        }
    }
}