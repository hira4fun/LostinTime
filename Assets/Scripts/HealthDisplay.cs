using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    private enum LastChangedScript { Arc, Cave, Wiz };
    private LastChangedScript lastChangedScript;

    public TextMeshProUGUI healthText;

    void Update()
    {
        float health = 0f;

        // Check which script changed last and get the health value from that script
        switch (lastChangedScript)
        {
            case LastChangedScript.Arc:
                health = ArcController.health;
                break;
            case LastChangedScript.Cave:
                health = CaveController.health;
                break;
            case LastChangedScript.Wiz:
                health = WizController.health;
                break;
        }

        // Update the health text
        healthText.text = "HEALTH : " + health;
    }

    // Set the lastChangedScript variable when a script updates its health value
    public void SetLastChangedScript(string scriptName)
    {
        switch (scriptName)
        {
            case "ArcController":
                lastChangedScript = LastChangedScript.Arc;
                break;
            case "CaveController":
                lastChangedScript = LastChangedScript.Cave;
                break;
            case "WizController":
                lastChangedScript = LastChangedScript.Wiz;
                break;
        }
    }
}
