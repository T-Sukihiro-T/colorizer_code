using UnityEngine;
using UnityEngine.UI;

public class MultiplierManager : MonoBehaviour
{
    public static MultiplierManager Mm;
    public Text currentMultiplier;

    public int multiplierTracker;

    public int otherTracker;
    // Start is called before the first frame update
    void Start()
    {
        Mm = this;
        multiplierTracker = 1;
        otherTracker = 1;

        currentMultiplier.text = "Multiplier: x" + 1.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        currentMultiplier.text = "Multiplier: x" + otherTracker.ToString();
    }
}
