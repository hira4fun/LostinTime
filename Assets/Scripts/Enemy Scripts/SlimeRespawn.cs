using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeRespawn : MonoBehaviour
{
    public GameObject respawningSlime;
    public RespawnDetection respawnDetection;
    bool playerDetected;
    bool enemyDetected;
    bool hasRespawned;

    // Update is called once per frame
    void Update()
    {
        playerDetected = respawnDetection.playerDetected;
        enemyDetected = respawnDetection.enemyDetected;
        CheckForRespawn();
    }
    
    public void CheckForRespawn(){
        if(!playerDetected && !enemyDetected && !hasRespawned){
            Invoke("Respawn", 5f);
        }
    }

    public void Respawn(){
        if(!playerDetected && !enemyDetected && !hasRespawned){
            Instantiate(respawningSlime);
            Debug.Log("Enemy respawned");
            hasRespawned = true;
        } else if (hasRespawned && (playerDetected || enemyDetected)){
            hasRespawned = false;
        }
    }       
}