using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class GameManagement : MonoBehaviour
{
    private static GameManagement _instance;
    
    // Start is called before the first frame update
    public static GameManagement Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError(("GameManager is NULL"));
            }

            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance)
            Destroy(gameObject);
        else
        {
            _instance = this;
        }
        
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        // Reloads current scene
        if (Input.GetKeyDown(KeyCode.Period))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void ChangeScenes(int index)
    {
        SceneManager.LoadScene(index);
    }
}
