using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [System.Serializable]
    public class DialogueLine
    {
        public string text;
        public Sprite characterSprite;
    }

    [System.Serializable]
    public class DialogueBranch
    {
        public string choiceText;
        public DialogueLine[] response;
    }

    public TextMeshProUGUI dialogueText;
    public Image characterImage;
    public Button nextButton;
    public GameObject choicePanel; // Panel containing choice buttons
    public Button[] choiceButtons; // Array of choice buttons

    private DialogueLine[] currentDialogue;
    private int dialogueIndex = 0;
    private bool isBranching = false;

    [Header("Dialogue Sequences")]
    public DialogueLine[] introDialogue; // Initial dialogue
    public DialogueBranch[] choices; // Choices leading to different branches

    void Start()
    {
        StartDialogue(introDialogue);
    }

    public void StartDialogue(DialogueLine[] dialogue)
    {
        currentDialogue = dialogue;
        dialogueIndex = 0;
        isBranching = false;
        choicePanel.SetActive(false);
        nextButton.gameObject.SetActive(true);
        ShowDialogue();
    }

    public void ShowDialogue()
    {
        nextButton.interactable = true;
        if (dialogueIndex < currentDialogue.Length)
        {
            dialogueText.text = currentDialogue[dialogueIndex].text;
            characterImage.sprite = currentDialogue[dialogueIndex].characterSprite;
            dialogueIndex++;
        }
        else
        {
            if (!isBranching)
            {
                ShowChoices();
            }
            else
            {
                nextButton.interactable = true;
            }
        }
    }

    public void ShowChoices()
    {
        isBranching = true;
        nextButton.gameObject.SetActive(false);
        choicePanel.SetActive(true);

        for (int i = 0; i < choices.Length; i++)
        {
            int index = i; // Capture loop variable
            choiceButtons[i].gameObject.SetActive(true);
            choiceButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = choices[i].choiceText;
            choiceButtons[i].onClick.RemoveAllListeners();
            choiceButtons[i].onClick.AddListener(() => StartDialogue(choices[index].response));
        }
    }
}
