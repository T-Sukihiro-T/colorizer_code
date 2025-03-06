using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Music_Files
{
    
}
public class TimerScript : MonoBehaviour
{
    private bool isDelayed = true;
    public float delay;
    public TextMeshProUGUI timerText;
    private int currentTimeInSec;
    
    // Start is called before the first frame update
    void Start()
    {
        currentTimeInSec = 0;
        StartCoroutine(updateTimer());
    }
    
    private IEnumerator updateTimer()
    {
        while (true)
        {
            if (!PauseGame.isPaused)
            {
                if (isDelayed)
                {
                    yield return new WaitForSeconds(delay);
                }

                while (true)
                {
                    yield return new WaitForSeconds(1.0f);
                    ++currentTimeInSec;
                    timerText.text = currentTimeInSec.ToString();
                }
            }
        }
    }
}
