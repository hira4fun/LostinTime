using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrigger : Trigger
{
    public GameObject TextBox;
    // public GameObject HeadBox;
    public List<string> unreadPages; // List of unread pages
    public List<string> readPages; // List of read pages
    public List<int> emotes;
    public RuntimeAnimatorController controller;
    public Sprite startSprite;
    public AudioManager audioManager;
    public bool isTalking;
    GameObject instance;
    // GameObject instance;
    // GameObject headInstance;
    void Start()
    {
        playerTag = "Player";
    }

    void InstantiateDialogue()
    {
        instance = Instantiate(TextBox, TextBox.transform.position, Quaternion.identity);
        instance.SetActive(true);
        Dialogue dialogue = instance.GetComponent<Dialogue>();

        List<string> pagesToUse; // List of pages to use in the dialogue

        if (unreadPages.Count > 0)
        {
            // If there are unread pages, create a copy of unreadPages list to use
            pagesToUse = new List<string>(unreadPages);
            unreadPages.Clear(); // Clear the unread pages list
        }
        else
        {
            // Otherwise, use the read pages
            pagesToUse = readPages;
        }

        dialogue.pages = pagesToUse;
        dialogue.emotes = emotes;
        dialogue.controller = controller;
        dialogue.audioManager = audioManager;
        dialogue.isOpen = true;
        dialogue.isTalking = isTalking;
    }

    public override void Action()
    {
        InstantiateDialogue();
    }
}