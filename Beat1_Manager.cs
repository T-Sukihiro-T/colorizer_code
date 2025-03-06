using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Beat1Manager : MonoBehaviour
{
    public AudioSource source;

    public VideoPlayer karaokeBackground;

    public bool startPlaying;

    public MoveNotes beats;

    public static Beat1Manager instance;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                beats.hasStarted = true;
                
                source.Play();
                
                karaokeBackground.Play();
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Scenes/Main");
        }
        
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Application.Quit();
            SceneManager.LoadScene("Scenes/Main Menu");
        }
    }

    public void NoteHit()
    {
        Debug.Log("Hit on time");
    }

    public void NoteMissed()
    {
        Debug.Log(("You missed silly"));
    }
}