using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Scenes/Charles Scene");
    }

    public void QuitGameFunny()
    {
        Application.Quit();
    }
}
