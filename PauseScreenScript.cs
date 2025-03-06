using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreenScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResumeGame()
    {
        PauseGame.isResumed = true;
    }

    public void QuitGame()
    {
        GameManagement.Instance.ChangeScenes(0);
    }
        
}
