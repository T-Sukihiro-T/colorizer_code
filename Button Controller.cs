using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private SpriteRenderer _color;

    public Sprite unpressedButton;
    public Sprite pressedButton;

    public KeyCode playerInput;
    
    // Start is called before the first frame update
    void Start()
    {
        _color = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(playerInput))
        {
            _color.sprite = pressedButton;
        }

        if (Input.GetKeyUp(playerInput))
        {
            _color.sprite = unpressedButton;
        }
    }
}
