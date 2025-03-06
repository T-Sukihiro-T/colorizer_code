using UnityEngine;
using UnityEngine.UI;

public class ChangeScore : MonoBehaviour
{
    public Text scoreText;
    public static ChangeScore CScore;

    public int score;

    public int multiplier;
    // Start is called before the first frame update
    void Start()
    {
        //scoreText.GetComponent<Text>();
        CScore = this;
        score = 0;
        multiplier = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //score += score + (100 * multiplier);
        scoreText.text = "Score " + score.ToString();
    }
}
