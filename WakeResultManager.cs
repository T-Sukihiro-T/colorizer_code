using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WakeResultManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fadeScreenIn;
    public GameObject char_ready_guy;
    public GameObject textBox;
    public GameObject charName;
    public int eventPos = 0;
    public bool isTyping = false;

    private List<IEnumerator> events = new List<IEnumerator>();

    [SerializeField] string textToSpeak;
    [SerializeField] int currentTextLength;
    [SerializeField] int textLength;
    [SerializeField] GameObject mainTextObject;

    // Start is called before the first frame update
    void Start()
    {
        events.Add(EventStarter());
    }

    // Update is called once per frame
    void Update()
    {
        textLength = TextCreator.charCount;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            textLength = TextCreator.charCount;

            if (Input.GetKeyDown(KeyCode.Space) && !isProcessingInput)
            {
                HandleDialogueInput();
            }
        }

    }

    // Prevents multiple space presses from causing issues
    private bool isProcessingInput = false;

    void HandleDialogueInput()
    {
        if (isProcessingInput) return; // Prevents multiple inputs from stacking

        isProcessingInput = true;

        if (isTyping)
        {
            // If text is still typing, instantly complete it
            SkipToFullText();
        }
        if (eventPos < events.Count)
        {
            // Move to the next event only when typing is finished
            StartCoroutine(StartNextDialogue());
        }
        else
        {
            SceneManager.LoadScene("Colorizer Main");
        }

        isProcessingInput = false;
    }

    void SkipToFullText()
    {
        StopAllCoroutines(); // Stop the typing effect
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak; // Show full text instantly
        isTyping = false; // Allow skipping after this
    }

    IEnumerator StartNextDialogue()
    {
        isTyping = true; // Prevents triggering next event too soon
        yield return StartCoroutine(events[eventPos]); // Run the event
        eventPos++;
        isTyping = false; // Now player can proceed to next dialogue
    }

    IEnumerator EventStarter()
    {
        yield return new WaitForSeconds(2);
        fadeScreenIn.SetActive(false);
        textBox.SetActive(true);

        char_ready_guy.SetActive(true);
        mainTextObject.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Main Character";
        textToSpeak = "Ehhhhhh I think ima just go back to sleep....... (End of Chapter)";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
    }

}
