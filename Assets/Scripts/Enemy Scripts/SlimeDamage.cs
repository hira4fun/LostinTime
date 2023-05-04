using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeDamage : MonoBehaviour
{

    public float damage = 1;
    public AudioManager audioManager;


    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Player2" || other.gameObject.tag == "Player3"){
            // Damages architect
            ArcController arcController = other.GetComponent<ArcController>();
            if(arcController != null) {
                arcController.Health -= damage;
                audioManager.Play("slime");
            }
            // Damages caveman
            CaveController caveController = other.GetComponent<CaveController>();
            if(caveController != null) {
                caveController.Health -= damage;
                audioManager.Play("slime");
            }
            // Damages wizard
            WizController wizController = other.GetComponent<WizController>();
            if(wizController != null) {
                wizController.Health -= damage;
                audioManager.Play("slime");
            }
        }
    }
}
