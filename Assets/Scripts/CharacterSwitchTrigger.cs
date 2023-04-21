using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSwitchTrigger : Trigger
{
    public GameObject originalCharacter;
    public GameObject newCharacter;
    public AudioManager audioManager;
    public TextMeshProUGUI essenceText;

    private EssenceDisplay essenceDisplay; // Reference to EssenceDisplay script

    // Start is called before the first frame update
    void Start()
    {
        essenceDisplay = FindObjectOfType<EssenceDisplay>(); // Find and store the EssenceDisplay script
    }

    public override void Action()
    {
        if (essenceDisplay != null && essenceDisplay.essence >= 5) // Check if EssenceDisplay script exists and essence is greater than or equal to 5
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

            essenceDisplay.essence -= 5; // Lower the essence value in EssenceDisplay script by 5
            essenceText.text = "Essence : " + essenceDisplay.essence; // Update the essence text with the new value
        }
    }
}