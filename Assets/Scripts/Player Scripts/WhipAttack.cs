using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipAttack : MonoBehaviour
{
    public Collider2D whipCollider;
    public float damage = 3;

    public void Attack() {
        whipCollider.enabled = true;
    }

    public void StopAttack() {
        whipCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy" || other.tag == "Destructible") {
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