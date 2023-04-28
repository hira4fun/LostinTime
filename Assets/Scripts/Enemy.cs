using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour
{
    public AudioManager audioManager;
    public TextMeshProUGUI essenceText;
    private EssenceDisplay essenceDisplay; // Reference to EssenceDisplay script


    public float Health
    {
        set
        {
            health = value;

            if (health <= 0)
            {
                Defeated();
            }
        }
        get
        {
            return health;
        }
    }

    public float health = 1;

    private void Start()
    {
        essenceDisplay = FindObjectOfType<EssenceDisplay>(); // Find and store the EssenceDisplay script

    }

    public void Defeated()
    {
        RemoveEnemy();
    }

    private void RemoveEnemy()
    {
        Destroy(gameObject);
        audioManager.Play("barrel");
        essenceDisplay.essence++; // Raise the essence value in EssenceDisplay script by 1
        essenceText.text = "Essence : " + essenceDisplay.essence; // Update the essence text with the new value
    }
}