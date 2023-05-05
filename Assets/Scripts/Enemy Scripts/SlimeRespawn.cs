using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeRespawn : MonoBehaviour
{
    public GameObject respawningSlime;
    public RespawnDetection respawnDetection;
    float enemyDetected;
    bool hasRespawned;
    public float spawnTimer = 3f;
    public AudioManager audioManager;

    // Update is called once per frame
    void Update()
    {
        enemyDetected = respawnDetection.enemyDetected;
        if(enemyDetected == 0 && !hasRespawned){
            Invoke("CheckForRespawn", spawnTimer);
            Debug.Log("CheckForRespawn");
        }
    }

    public void CheckForRespawn()
    {
        if(enemyDetected == 0 && !hasRespawned){
            Invoke("Respawn", spawnTimer);
            Debug.Log("Respawn");
        }
    }

    public void Respawn()
    {
        if(enemyDetected == 0 && !hasRespawned){
            GameObject enemy = Instantiate(respawningSlime, transform.position, transform.rotation);
            SlimeDamage slimeDamage = enemy.GetComponentInChildren<SlimeDamage>();
            EnemySlime enemySlime = enemy.GetComponent<EnemySlime>();
            slimeDamage.audioManager = audioManager;
            enemySlime.audioManager = audioManager;
            Debug.Log("Enemy respawned");
            hasRespawned = true;
        } else if (hasRespawned && enemyDetected >= 1){
            hasRespawned = false;
        }
    }
}