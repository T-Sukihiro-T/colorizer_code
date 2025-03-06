using UnityEngine;

public class Success : MonoBehaviour
{
    public static Success Ding;
    public AudioSource audioSource;

    public AudioClip scored;
    // Start is called before the first frame update
    void Start()
    {
        Ding = this;
    }

    public void PlaySound()
    {
        audioSource.pitch = Random.Range(0.5f, 1f);
        audioSource.PlayOneShot(scored);
    }
}
