using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour
{
    public float songBpm; // The beat per minute of the current song
    public float secPerBeat; // The how many seconds are in each song's beat
    public float songPosition; // Current song positions in seconds
    public float songPositionInBeats; // Current song position in terms of beats
    public float dspSongTime; // How many seconds have passed since the song started
    public AudioSource musicSource; // The audio source that will play the music
    public float firstBeatOffset;
    
    // Start is called before the first frame update
    void Start()
    {
        musicSource = GetComponent<AudioSource>();
        secPerBeat = 60f / songBpm;
        dspSongTime = (float)AudioSettings.dspTime;
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        // Calculates how far in the song the game is
        songPosition = (float)(AudioSettings.dspTime - dspSongTime - firstBeatOffset);

        // Converts song position from seconds to beats
        songPositionInBeats = songPosition / secPerBeat;
    }
}
