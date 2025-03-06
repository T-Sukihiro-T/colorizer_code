using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string sceneName = "Main"; // Set this in the Inspector

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Detect Spacebar Press
        {
            LoadSpecificScene();
        }
    }

    void LoadSpecificScene()
    {
        if (!string.IsNullOrEmpty(sceneName)) // Check if a scene name is set
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("Scene name is not set in the Inspector!");
        }
    }
}
