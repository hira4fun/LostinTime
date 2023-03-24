using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitchTrigger : Trigger
{
    public GameObject originalCharacter;
    public GameObject newCharacter;
    public AudioManager audioManager;


    public override void Action()
    {
        // Switch the active character
        audioManager.Play("trans");
        if (!originalCharacter.activeSelf)
        {
            originalCharacter.SetActive(true);
            newCharacter.SetActive(false);
        }
        else
        {
            originalCharacter.SetActive(false);
            newCharacter.SetActive(true);
        }
    }
}