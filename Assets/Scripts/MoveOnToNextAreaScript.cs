using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnToNextAreaScript : Trigger
{
    GameObject instance;
    public BoxCollider2D box;
    public GameObject boxSprite;
    public AudioManager audioManager;
    public CircleCollider2D text;
    

    public override void Action()
    {
        
        audioManager.Play("door");
        box.isTrigger = true;
        boxSprite.SetActive(true);
        text.enabled = false;

        //Debug.Log(isTrigger);
    }


}
