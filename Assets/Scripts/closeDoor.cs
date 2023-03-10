using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeDoor : Trigger
{

    GameObject instance;
    bool isTrigger = true;
    public BoxCollider2D box;
    public GameObject boxSprite;

    public override void Action()
    {
        isTrigger = false;
        box.isTrigger = false;
        boxSprite.SetActive(false);

        //Debug.Log(isTrigger);
    }


}


