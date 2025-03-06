using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManageSettings : MonoBehaviour
{
    public GameObject title;
    public GameObject playGame;
    public GameObject settings;
    public GameObject quit;

    public GameObject slider;
    public GameObject sliderText;
    public GameObject loadMainMenu;
    public GameObject settingsTitle;

    private void Start()
    {
        loadMainMenu.SetActive(false);
        settingsTitle.SetActive(false);
        // sliderText.SetActive(false);
        slider.SetActive(false);
    }

    public void LoadSettings()
    {
        title.SetActive(false);
        playGame.SetActive(false);
        settings.SetActive(false);
        quit.SetActive(false);
        
        loadMainMenu.SetActive(true);
        settingsTitle.SetActive(true);
        slider.SetActive(true);
        // sliderText.SetActive(true);
    }

    public void ReloadMainMenu()
    {
        title.SetActive(true);
        playGame.SetActive(true);
        settings.SetActive(true);
        quit.SetActive(true);
        
        loadMainMenu.SetActive(false);
        settingsTitle.SetActive(false);
        slider.SetActive(false);
        // sliderText.SetActive(false);
    }
}
