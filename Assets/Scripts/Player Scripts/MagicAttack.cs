using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicAttack : MonoBehaviour
{
    public Collider2D magicCollider;
    public float damage = 3;
    public float speed = 120;
    Vector3 defaultPos = new Vector3(0, 0, 0);

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

    public void Update() {
        if(magicCollider.enabled == true) {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
        if(magicCollider.enabled == false){
            transform.position = defaultPos;
        }
    }

    public void Attack() {
        magicCollider.enabled = true;
    }

    public void StopAttack() {
        magicCollider.enabled = false;
        transform.position = defaultPos;
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