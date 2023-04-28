using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;

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