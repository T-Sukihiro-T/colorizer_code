using UnityEngine;

public class MoveNotes : MonoBehaviour
{
    public float scrollSpeed;

    public bool hasStarted;
    
    // Start is called before the first frame update
    void Start()
    {
        scrollSpeed = scrollSpeed / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            // if (Input.anyKeyDown)
            // {
            //     hasStarted = true;
            // }
        }

        else
        {
            {
                transform.position -= new Vector3(0f, scrollSpeed * Time.deltaTime, 0f);
            }
        }
    }
}
