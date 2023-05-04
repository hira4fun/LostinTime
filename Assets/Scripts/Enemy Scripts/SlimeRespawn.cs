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
    public float spawnTimer = 5f;
    public AudioManager audioManager;

    // Update is called once per frame
    void Update()
    {
        playerDetected = respawnDetection.playerDetected;
        enemyDetected = respawnDetection.enemyDetected;
        CheckForRespawn();
    }

    public void CheckForRespawn()
    {
        if (!playerDetected && !enemyDetected && !hasRespawned)
        {
            Invoke("Respawn", spawnTimer);
        }
    }

    public void Respawn()
    {
        if (!playerDetected && !enemyDetected && !hasRespawned)
        {
            GameObject enemy = Instantiate(respawningSlime, transform.position, transform.rotation);
            SlimeDamage slimeDamage = enemy.GetComponentInChildren<SlimeDamage>();
            slimeDamage.audioManager = audioManager;
            Debug.Log("Enemy respawned");
            hasRespawned = true;
        }
        else if (hasRespawned && (playerDetected || enemyDetected))
        {
            hasRespawned = false;
        }
    }
}
