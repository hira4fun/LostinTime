using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    private int health = 5;
    public TextMeshProUGUI healthText;

    void Update()
    {
        healthText.text = "HEALTH : " + health;
        if (Input.GetKeyDown(KeyCode.H))
        {
            health--;
        }
    }
}
