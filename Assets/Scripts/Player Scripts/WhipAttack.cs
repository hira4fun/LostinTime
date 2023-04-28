using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipAttack : MonoBehaviour
{
    public Collider2D whipCollider;
    public float damage = 3;
    Vector2 southAttackOffset;

    private void Start() {
        southAttackOffset = transform.position;
    }

    public void AttackSouth() {
        whipCollider.enabled = true;
        transform.localPosition = southAttackOffset;
    }

    public void AttackNorth() {
        whipCollider.enabled = true;
        transform.localPosition = new Vector3(southAttackOffset.x, southAttackOffset.y * -1);
    }

    public void StopAttack() {
        whipCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy") {
            // Deal damage to the enemy
            Enemy enemy = other.GetComponent<Enemy>();

            if(enemy != null) {
                enemy.Health -= damage;
            }
        }
    }
}
