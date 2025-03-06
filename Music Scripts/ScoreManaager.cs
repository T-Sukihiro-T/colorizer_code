using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Music_Files
{
    
}

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public AudioSource hitSFX;
    public AudioSource missSFX;
    public TMPro.TextMeshPro comboText;
    public TMPro.TextMeshPro scoreText;
    public TMPro.TextMeshPro performanceText;
    static int comboScore;
    private static int noteScore;
    void Start()
    {
        instance = this;
        comboScore = 0;
        noteScore = 0;
        performanceText.text = "";
    }
    public static void Hit(double marginPercent)
    {
        // // Ok Hit
        // if (marginPercent >= 0.95f || marginPercent <= 0.05f)
        // {
        //     noteScore += 10;
        //     instance.performanceText.text = "Ok!";
        // }
        //
        // // Good Hit
        // else if (marginPercent >= 0.75f || marginPercent <= 0.25f)
        // {
        //     noteScore += 25;
        //     instance.performanceText.text = "Good!";
        // }
        //
        // // Great Hit
        // else if (marginPercent >= 65 || marginPercent <= 45)
        // {
        //     noteScore += 50;
        //     instance.performanceText.text = "Great!";
        // }
        //
        // // Perfect Hit
        // else
        // {
        //     noteScore += 100;
        //     instance.performanceText.text = "Perfect";
        // }

        noteScore += 100;
        comboScore += 1;
        instance.hitSFX.Play();
    }
    public static void Miss()
    {
        comboScore = 0;
        instance.missSFX.Play();    
    }

    public int getFinalScore()
    {
        return noteScore;
    }

    private void Update()
    {
        scoreText.text = "Score: " + noteScore.ToString();
        comboText.text = "Combo: " + comboScore.ToString();
    }
}