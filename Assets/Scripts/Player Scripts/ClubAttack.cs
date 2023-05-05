using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClubAttack : MonoBehaviour
{
    public Collider2D clubCollider;
    public float damage = 4;

    public void Attack() {
        clubCollider.enabled = true;
    }

    public void StopAttack() {
        clubCollider.enabled = false;
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