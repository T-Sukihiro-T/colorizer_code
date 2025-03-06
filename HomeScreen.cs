using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScreen : MonoBehaviour
{
    
    public void PlayGame()
    {
        SceneManager.LoadScene("VN_vertical_slice");
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
