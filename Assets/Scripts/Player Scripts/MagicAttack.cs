using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicAttack : MonoBehaviour
{
    public Collider2D magicCollider;
    public float damage = 3;
    public float speed = 200;

    public void Update() {

        if(magicCollider.enabled == true) {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        if(magicCollider.enabled == false){
            
        }
    }

    public void ResetPos(){
        transform.localPosition = new Vector3(0, -1, 0);
    }

    public void Attack() {
        ResetPos();
        magicCollider.enabled = true;
    }

    public void StopAttack() {
        magicCollider.enabled = false;
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