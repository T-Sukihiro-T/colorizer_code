using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using System.IO;
using UnityEngine.Networking;
using System;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using System.Reflection;

namespace Music_Files
{
    
}

public class SongManager : MonoBehaviour
{
    public static SongManager instance;
    public AudioSource audioSource;
    public Lane[] lanes;
    public float songDelayInSeconds;
    public double marginOfError; // in seconds

    public int inputDelayInMilliseconds;
    

    public string fileLocation;
    public float noteTime;
    public float noteSpawnY;
    public float noteTapY;

    private float totalSongLength;

    public int nextIndex;
    
    public float NoteDespawnY
    {
        get
        {
            return noteTapY - (noteSpawnY - noteTapY);
        }
    }

    public static MidiFile midiFile;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        ReadFromFile();
    }

    private void ReadFromFile()
    {
        midiFile = MidiFile.Read(Application.streamingAssetsPath + "/" + fileLocation);
        GetDataFromMidi();
    }
    public void GetDataFromMidi()
    {
        var notes = midiFile.GetNotes();
        var array = new Melanchall.DryWetMidi.Interaction.Note[notes.Count];
        notes.CopyTo(array, 0);

        foreach (var lane in lanes) lane.SetTimeStamps(array);
        totalSongLength = audioSource.clip.length;
        
        Invoke(nameof(StartSong), songDelayInSeconds);
    }
    public void StartSong()
    {
        audioSource.Play();
    }
    
    public static double GetAudioSourceTime()
    {
        return (double) instance.audioSource.timeSamples / instance.audioSource.clip.frequency;
    }

    void Update()
    {
        if (!PauseGame.isPaused)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.UnPause();
            }
            
            if ((int)GetAudioSourceTime() >= (int)totalSongLength)
            {
                StartCoroutine(EventEnd());
            }

            if (audioSource.isPlaying && totalSongLength > 0)
            {
                var progress = (float)GetAudioSourceTime() / totalSongLength;
                ProgressBar.instance.IncrementProgress(Mathf.Clamp01(progress));
            }
        }

        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Pause();
            }
        }
    }

    IEnumerator EventEnd()
    {
        Debug.Log("we made it");
        yield return new WaitForSeconds(2);

        if(ScoreManager.instance.getFinalScore() > 5000)
        {
            SceneManager.LoadScene("Wake_resultV1");
        }
        else if (ScoreManager.instance.getFinalScore() < 5000)
        {
            SceneManager.LoadScene("Wake_resultV2");
        }
    }
}