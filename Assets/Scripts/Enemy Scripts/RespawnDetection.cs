using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnDetection : MonoBehaviour
{
    public string tagTarget = "Enemy";
    public float enemyDetected;

    public List<Collider2D> detectedObjs = new List<Collider2D>();

    public Collider2D col;

    // Start is called before the first frame update
    void Start()
    {
        col.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == tagTarget){      
            detectedObjs.Add(collider);
            enemyDetected += 1;
        }
    }

    void OnTriggerExit2D(Collider2D collider){
        if(collider.gameObject.tag == tagTarget){      
            detectedObjs.Remove(collider);
            enemyDetected -= 1;
        }
    }
}