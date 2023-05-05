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
    public float spawnTimer = 3f;
    public AudioManager audioManager;
    public bool closeRespawn;

    // Update is called once per frame
    void Update()
    {
        playerDetected = respawnDetection.playerDetected;
        enemyDetected = respawnDetection.enemyDetected;
        if (closeRespawn == false)
        {
            if (!playerDetected && !enemyDetected && !hasRespawned)
            {
                Invoke("CheckForRespawn", spawnTimer);
            }
        } else if (closeRespawn == true)
        {
            if (!enemyDetected && !hasRespawned)
            {
                Invoke("CheckForRespawn", spawnTimer);
            }
        }
    }

    public void CheckForRespawn()
    {
        if (closeRespawn == false)
        {
            if (!playerDetected && !enemyDetected && !hasRespawned)
            {
                Invoke("Respawn", spawnTimer);
            }
        } else if (closeRespawn == true)
        {
            if (!enemyDetected && !hasRespawned)
            {
                Invoke("Respawn", spawnTimer);
            }
        }
    }

    public void Respawn()
    {
        if (closeRespawn == false)
        {
            if (!playerDetected && !enemyDetected && !hasRespawned)
            {
                GameObject enemy = Instantiate(respawningSlime, transform.position, transform.rotation);
                SlimeDamage slimeDamage = enemy.GetComponentInChildren<SlimeDamage>();
                EnemySlime enemySlime = enemy.GetComponent<EnemySlime>();
                slimeDamage.audioManager = audioManager;
                enemySlime.audioManager = audioManager;
                Debug.Log("Enemy respawned");
                hasRespawned = true;
            } else if (hasRespawned && (playerDetected && enemyDetected))
            {
                hasRespawned = false;
            }
        } else if (closeRespawn == true)
        {
            if (!enemyDetected && !hasRespawned)
            {
                GameObject enemy = Instantiate(respawningSlime, transform.position, transform.rotation);
                SlimeDamage slimeDamage = enemy.GetComponentInChildren<SlimeDamage>();
                EnemySlime enemySlime = enemy.GetComponent<EnemySlime>();
                slimeDamage.audioManager = audioManager;
                enemySlime.audioManager = audioManager;
                Debug.Log("Enemy respawned");
                hasRespawned = true;
            } else if (hasRespawned && enemyDetected)
            {
                hasRespawned = false;
            }            
        }
    }
}