using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalsound : Trigger
{
    GameObject instance;
    public CircleCollider2D circle;
    public AudioManager audioManager;

    public override void Action()
    {
        audioManager.Play("portal");
        Debug.Log("sound effect");

    }
}
