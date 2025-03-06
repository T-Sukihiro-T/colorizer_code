using Melanchall.DryWetMidi.Interaction;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Music_Files
{
    
}
 // rtyu buttons for notes
public class Lane : MonoBehaviour
{
    public Melanchall.DryWetMidi.MusicTheory.NoteName noteRestriction;
    public KeyCode input;
    public GameObject notePrefab;
    List<Note> notes = new List<Note>();
    public List<double> timeStamps = new List<double>();

    int spawnIndex = 0;
    int inputIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SetTimeStamps(Melanchall.DryWetMidi.Interaction.Note[] array)
    {
        if (!PauseGame.isPaused)
        {
            foreach (var note in array)
            {
                if (note.NoteName == noteRestriction)
                {
                    var metricTimeSpan = TimeConverter.ConvertTo<MetricTimeSpan>(note.Time, SongManager.midiFile.GetTempoMap());
                    timeStamps.Add((double)metricTimeSpan.Minutes * 60f + metricTimeSpan.Seconds + (double)metricTimeSpan.Milliseconds / 1000f);
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!PauseGame.isPaused)
        {
            if (spawnIndex < timeStamps.Count)
            {
                if (SongManager.GetAudioSourceTime() >= timeStamps[spawnIndex] - SongManager.instance.noteTime)
                {
                    var note = Instantiate(notePrefab, transform);
                    
                    // Debug
                    Note noteComponent = note.GetComponent<Note>();
                    if (noteComponent == null)
                    {
                        Debug.LogError("Instantiated note does not have a Note component");
                        return;
                    }
                    
                    notes.Add(note.GetComponent<Note>());
                    note.GetComponent<Note>().assignedTime = (float)timeStamps[spawnIndex];
                    spawnIndex++;
                }
            }
    
            if (inputIndex < timeStamps.Count)
            {
                double timeStamp = timeStamps[inputIndex];
                double marginOfError = SongManager.instance.marginOfError;
                double audioTime = SongManager.GetAudioSourceTime() - (SongManager.instance.inputDelayInMilliseconds / 1000.0);
    
                if (Input.GetKeyDown(input))
                {
                    if (Math.Abs(audioTime - timeStamp) < marginOfError)
                    {
                        double marginPercent = (audioTime - timeStamp) / marginOfError;
                        Hit(marginPercent);
                        print($"Hit on {inputIndex} note");
                        Destroy(notes[inputIndex].gameObject);
                        inputIndex++;
                    }
                    else
                    {
                        Miss();
                        print($"Hit inaccurate on {inputIndex} note with {Math.Abs(audioTime - timeStamp)} delay");
                    }
                }
                if (timeStamp + marginOfError <= audioTime)
                {
                    Miss();
                    print($"Missed {inputIndex} note");
                    inputIndex++;
                }
            }   
        }
    }
    private void Hit(double marginPercent)
    {
        ScoreManager.Hit(marginPercent);
    }
    private void Miss()
    {
        ScoreManager.Miss();
    }
}