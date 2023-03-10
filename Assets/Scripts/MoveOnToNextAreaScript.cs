using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnToNextAreaScript : Trigger
{
    GameObject instance;
    bool isTrigger = false;
    public BoxCollider2D box;
    public GameObject boxSprite;

    public override void Action()
    {
        isTrigger = true;
        box.isTrigger = true;
        boxSprite.SetActive(true);

        //Debug.Log(isTrigger);
    }


}
