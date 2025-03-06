using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class VN_vertical_slice_events : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fadeScreenIn;
    public GameObject char_groggy_guy;
    public GameObject char_friend_guy;
    public GameObject char_MainGuy;
    public GameObject textBox;
    public GameObject charName;
    public int eventPos = 0;
    public bool isTyping = false;

    private List<IEnumerator> events = new List<IEnumerator>();

    [SerializeField] string textToSpeak;
    [SerializeField] int currentTextLength;
    [SerializeField] int textLength;
    [SerializeField] GameObject mainTextObject;

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
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("Colorizer Main");
            } 
        }
    }


    void Start()
    { 
        events.Add(EventStarter());
        events.Add(EventOne());
        events.Add(EventTwo());
        events.Add(EventThree());
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
            SceneManager.LoadScene("Charles Scene");
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

        mainTextObject.SetActive(true);
        textToSpeak = "*KNOCK* *KNOCK* *KNOCK*" + "\n Hey dude you gotta get up! Class starts in 10 minutes!";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        textBox.SetActive(true);
        yield return new WaitForSeconds(2);
    }

    IEnumerator EventOne()
    {
        //Event 1
        yield return new WaitForSeconds(1);
        char_groggy_guy.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Main Character";
        textToSpeak = "Huh.....Whats he talking about, where am I?....";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        textBox.SetActive(true);
    }

    IEnumerator EventTwo()
    {
        yield return new WaitForSeconds(1);
        char_friend_guy.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Best Friend";
        textToSpeak = "Yeah get up! You dont wanna be late on your first day do ya?";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;

        yield return new WaitForSeconds(0.05f); // Small delay
        yield return new WaitForSeconds(1);    // Allow time for initial text reveal
        yield return new WaitUntil(() => textLength == currentTextLength); // Wait until all text is displayed
        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator EventThree()
    {
        char_friend_guy.SetActive(false);
        char_groggy_guy.SetActive(false);

        char_MainGuy.SetActive(true);

        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Main Character";
        textToSpeak = "Mannn crap....I just wanna dropout already....should I go back to sleep....... or get ready for class......";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;

        yield return new WaitForSeconds(0.05f); // Small delay
        yield return new WaitForSeconds(1);    // Allow time for initial text reveal
        yield return new WaitUntil(() => textLength == currentTextLength); // Wait until all text is displayed
        yield return new WaitForSeconds(0.5f);
    }
}
