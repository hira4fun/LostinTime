using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicAttack : MonoBehaviour
{
    public Collider2D magicCollider;
    public float damage = 4;
    public float speed = 2;
    public float x = 0;
    public float y = 0;
    Vector2 rightAttackOffset;

    /*
    Vector3.forward    (0,  0,  1)
    Vector3.back       (0,  0,  -1)
    Vector3.up         (0,  1,  0)
    Vector3.down       (0,  -1, 0)
    Vector3.right      (1,  0,  0)
    Vector3.left       (-1, 0,  0)

    transform.forward   object forward
    -transform.forward  object back
    transform.up        object up
    -transform.up       object down
    transform.right     object right
    -transform.right    object left
    */

    private void Start() {
        rightAttackOffset = transform.position;
    }

    public void Update() {
        if(magicCollider.enabled == true) {
            transform.localPosition += Vector3.down * speed * Time.deltaTime;
        } else {
            transform.localPosition = rightAttackOffset;
        }
    }

    public void AttackRight() {
        magicCollider.enabled = true;
        transform.localPosition = rightAttackOffset;
    }

    public void AttackLeft() {
        magicCollider.enabled = true;
        transform.localPosition = new Vector3(rightAttackOffset.x * -1, rightAttackOffset.y);
    }

    public void StopAttack() {
        magicCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy") {
            // Deal damage to the enemy
            Debug.Log("deal damage");
            Enemy enemy = other.GetComponent<Enemy>();

            if(enemy != null) {
                enemy.Health -= damage;
            }
        }
    }
}