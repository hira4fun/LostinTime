using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
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
        
    }

    public void Defeated() {
        RemoveEnemy();
    }

    private void RemoveEnemy() {
        Destroy(gameObject);
    }
}