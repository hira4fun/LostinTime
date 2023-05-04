using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnDetection : MonoBehaviour
{
    public string tagTarget = "Player";
    public string tagTarget2 = "Player2";
    public string tagTarget3 = "Player3";
    public string tagTarget4 = "Enemy";

    public bool playerDetected;
    public bool enemyDetected;

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
        if(collider.gameObject.tag == tagTarget || collider.gameObject.tag == tagTarget2 || collider.gameObject.tag == tagTarget3){      
            detectedObjs.Add(collider);
            playerDetected = true;
        }
        if(collider.gameObject.tag == tagTarget4){
            detectedObjs.Add(collider);
            enemyDetected = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider){
        if(collider.gameObject.tag == tagTarget || collider.gameObject.tag == tagTarget2 || collider.gameObject.tag == tagTarget3){      
            detectedObjs.Remove(collider);
            playerDetected = false;
        }
        if(collider.gameObject.tag == tagTarget4){
            detectedObjs.Remove(collider);
            enemyDetected = false;
        }
    }
}