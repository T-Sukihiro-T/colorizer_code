using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //public bool startSpawning;

    public bool songPlaying;

    public GameObject note;

    public float angle;

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            songPlaying = true;
            StartCoroutine(SpawnNotes());
        }
    }

    private IEnumerator SpawnNotes()
    {
        yield return 0.5f;

        while (songPlaying)
        {
            WaitForSeconds varyBeat = new WaitForSeconds(Random.Range(1,3));

            yield return varyBeat;

            Vector3 position = new Vector3(transform.position.x, transform.position.y, angle);
            
            Instantiate(note, position, Quaternion.identity);
        }
    }
}
