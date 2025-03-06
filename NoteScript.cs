using UnityEngine;

public class NoteScript : MonoBehaviour
{
    public bool canBePressed;

    public KeyCode correctKeyPressed;
    
    // public GameManager instance;
    
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer render = GetComponent<SpriteRenderer>();
        if (gameObject.name.Contains("Down Arrow"))
        {
            render.color = new Color(251, 44, 0);
        }
        
        else if (gameObject.name.Contains("Left Arrow"))
        {
            render.color = Color.blue;
        }
        
        else if (gameObject.name.Contains("Up Arrow"))
        {
            render.color = Color.red;
        }

        else
        {
            render.color = Color.green;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(correctKeyPressed))
        {
            if (canBePressed)
            {
                //gameObject.SetActive(false);
                Destroy(gameObject);

                MultiplierManager.Mm.multiplierTracker++;

                switch (MultiplierManager.Mm.multiplierTracker)
                {
                    case 5:
                        ChangeScore.CScore.multiplier += 1;
                        MultiplierManager.Mm.otherTracker += 1;
                        break;
                    
                    case 10:
                        ChangeScore.CScore.multiplier += 1;
                        MultiplierManager.Mm.otherTracker += 1;
                        break;
                    
                    case 25:
                        ChangeScore.CScore.multiplier += 1;
                        MultiplierManager.Mm.otherTracker += 1;
                        break;
                    
                    case 50:
                        ChangeScore.CScore.multiplier += 1;
                        MultiplierManager.Mm.otherTracker += 1;
                        break;
                    case 100:
                        ChangeScore.CScore.multiplier += 5;
                        MultiplierManager.Mm.otherTracker += 5;
                        break;
                }
                
                Success.Ding.PlaySound();
                
                // GameManager.instance.NoteHit();
                ChangeScore.CScore.score += 100 * ChangeScore.CScore.multiplier;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Activator"))
        {
            canBePressed = true;
        }
        
        else if (collision.name.Equals("Disappear Mortal"))
        {
            Destroy(gameObject);

            MultiplierManager.Mm.multiplierTracker = 1;
            MultiplierManager.Mm.otherTracker = 1;
            ChangeScore.CScore.multiplier = 1;
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Activator"))
        {
            canBePressed = false;
            
            Beat1Manager.instance.NoteMissed();
        }
    }
}
