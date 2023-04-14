using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeDoor : Trigger
{

    GameObject instance;
    public BoxCollider2D box;
    public GameObject boxSprite;
    public AudioManager audioManager;
    public float audioDelay = 0.1f;


    public override void Action()
    {
        Invoke("PlayAudio", audioDelay);
        box.isTrigger = false;
        boxSprite.SetActive(false);

        //Debug.Log(isTrigger);
    }

    void PlayAudio()
    {
        audioManager.Play("door");
    }


}


