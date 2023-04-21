using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EssenceDisplay : MonoBehaviour
{
    public int essence = 0;
    public TextMeshProUGUI healthText;


    void Update()
    {
        healthText.text = "Essence : " + essence;
        if (Input.GetKeyDown(KeyCode.J))
        {
            essence++;
        }
    }
}