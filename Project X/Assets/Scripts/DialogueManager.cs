using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueUI;
    public string dialogueText;
    public TMP_Text dialogueTextBox;
    public PlayerInputs inputs;
    public int maxCharLength = 1;

    bool playerInDialogue;
    List<string> textsToDisplay;

    void Start()
    {
        inputs = GameObject.FindWithTag("Player").GetComponent<PlayerInputs>();
        playerInDialogue = false;
        dialogueUI.SetActive(false);
        dialogueTextBox.text = "";
        textsToDisplay = SplitDialogueIntoLines(dialogueText);
        foreach (string i in textsToDisplay) {
            Debug.Log(i);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(inputs.interact))
        {
            Time.timeScale = 0;
            playerInDialogue = true;
            dialogueUI.SetActive(true);
            ChangeTextBoxText(dialogueText);
        }
    }

    void ChangeTextBoxText(string displayText)
    {
        dialogueTextBox.text = displayText;
    }


    //does not split lines at words
    List<string> SplitDialogueIntoLines(string textToSplit)
    {
        string remainingText = textToSplit;
        List<string> splitText = new List<string>();
        Debug.Log("Starting Dialogue Text Spliting");
        while (remainingText.Length > maxCharLength)
        {
            Debug.Log("Current text length is: " + remainingText.Length + " Splitting text.");
            splitText.Add(remainingText.Substring(0, maxCharLength));
            Debug.Log("Text segment appended to list.");
            remainingText = remainingText.Substring(maxCharLength, remainingText.Length - maxCharLength);
            Debug.Log("Moving to next text segment.");
        }
        Debug.Log(remainingText);
        splitText.Add(remainingText);
        Debug.Log("Text split successfully");
        return splitText;
    }
}
