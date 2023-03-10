using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipAttack : MonoBehaviour
{
	public float damage = 2;
	Vector2 southAttackOffset;
	Collider2D whipCollider;

	private void Start() {
		whipCollider = GetComponent<Collider2D>();
		southAttackOffset = transform.position;
	}

	public void AttackSouth() {
		print("Attack South");
		whipCollider.enabled = true;
		transform.position = southAttackOffset;
	}

	public void AttackNorth() {
		whipCollider.enabled = true;
		transform.position = new Vector3(southAttackOffset.x * -1, southAttackOffset.y);
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
