using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeDoor : Trigger
{

    GameObject instance;
    public BoxCollider2D box;
    public GameObject boxSprite;
    public AudioManager audioManager;

    public override void Action()
    {
        box.isTrigger = false;
        boxSprite.SetActive(false);
        audioManager.Play("doorslam");

        //Debug.Log(isTrigger);
    }


}


