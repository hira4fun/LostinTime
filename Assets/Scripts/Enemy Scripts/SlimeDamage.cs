using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeDamage : MonoBehaviour
{

    public float damage = 1;

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            // Damages architect
            ArcController arcController = other.GetComponent<ArcController>();
            if(arcController != null) {
                arcController.Health -= damage;
            }
            // Damages caveman
            CaveController caveController = other.GetComponent<CaveController>();
            if(caveController != null) {
                caveController.Health -= damage;
            }
        }
    }
}
