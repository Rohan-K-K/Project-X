using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueUI;
    public GameObject virtualPlayerCam;
    public GameObject virtualDialogueCam;
    public string dialogueText;
    public TMP_Text dialogueTextBox;
    public PlayerInputs inputs;
    public int maxCharLength = 1;

    List<string> textsToDisplay;
    int dialogueIndex = -1;

    void Start()
    {
        inputs = GameObject.FindWithTag("Player").GetComponent<PlayerInputs>();
        dialogueUI.SetActive(false);
        dialogueTextBox.text = "";
        textsToDisplay = SplitDialogueIntoLines(dialogueText);
        foreach (string i in textsToDisplay) {
            Debug.Log(i);
        }
    }

    void Update()
    {
        SetTextBoxText();
        scrollDialogue();
        endDialogue();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(inputs.interact))
        {
            virtualPlayerCam.SetActive(false);
            virtualDialogueCam.SetActive(true);
            dialogueUI.SetActive(true);
        }
    }

    void SetTextBoxText()
    {
        if (dialogueIndex > -1)
        {
            dialogueTextBox.text = textsToDisplay[dialogueIndex];
        }
    }

    void scrollDialogue()
    {
        if (Input.GetKeyDown(inputs.interact) || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            dialogueIndex += 1;
        }
    }

    void endDialogue()
    {
        if (dialogueIndex == textsToDisplay.Count)
        {
            virtualPlayerCam.SetActive(true);
            virtualDialogueCam.SetActive(false);
            Time.timeScale = 1;
            dialogueUI.SetActive(false);
            dialogueIndex = -1;
        }
    }

    //TODO: does not split lines at words, only at characters
    //TODO: switch to split at words once made
    List<string> SplitDialogueIntoLines(string textToSplit)
    {
        string remainingText = textToSplit;
        List<string> splitText = new List<string>();
        if (remainingText.Length < maxCharLength)
        {
            Debug.Log("Dialogue under max character length. No line splitting is required, returning origional string");
            return new List<string> { remainingText };
        }
        Debug.Log("Starting Dialogue Text Spliting");
        while (remainingText.Length > maxCharLength)
        {
            Debug.Log("Current text length is: " + remainingText.Length + " Splitting text.");
            splitText.Add(remainingText.Substring(0, maxCharLength));
            Debug.Log("Text segment appended to list.");
            remainingText = remainingText.Substring(maxCharLength, remainingText.Length - maxCharLength);
            Debug.Log("Moving to next text segment.");
        }
        if (remainingText.Length > 0)
        {
            splitText.Add(remainingText);
        }
        Debug.Log("Text split successfully");
        return splitText;
    }
}
