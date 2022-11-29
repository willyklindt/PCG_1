using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio; //Importing Unity sound package, so we with scripts can manipulate with unitys AudioMixer
using UnityEngine.UI; //G�r at vi kan tilg� elementer i UI
public class settingsMenuHandler : MonoBehaviour

   
{
    public AudioMixer soundMixer;

    public TMPro.TMP_Dropdown resolutionSelecter;
    Resolution[] resolutions; //arraylist som gemmer brugerens sk�rm resolutions

    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutionSelecter.ClearOptions(); //Sletter options i vores resolution dropdown menu, s� vi kan tilf�je vores egne options via nedenst�ende:

        List<string> options = new List<string>(); //Vi laver denne som List, da vi skal gemme v�rdierne fra Arraylist Resolution[] resolutions, som en string list istedet. List har ingen fixed size, ligesom ArrayList
        int preselectedResolution = 0; //Bruges til at s�tte brugers nuv�rende sk�rm resolution til default i dropdown menu 

        for (int i = 0; i < resolutions.Length; i++) //Dette loop tilf�jer alle sk�rm resolutions bruger har til dropdown listen
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height) //Tjekker om resolution i array der kigges p� == brugers nuv�rende resolutin
            {
                preselectedResolution = i; //Gemmer hvilket index i array, som brugers nuv�rende resolutin er p�
            }
        }
        resolutionSelecter.AddOptions(options);
        resolutionSelecter.value = preselectedResolution;
        resolutionSelecter.RefreshShownValue();
        //Ovenst�ende 3, m�ske man kan g�re det smartere i de nyere versioner af unity?

    }
    public void ChangeResolution (int preselectedResolution)
    {
        Resolution resolution = resolutions[preselectedResolution];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void changeSoundVolume(float soundVolume)
    {
        soundMixer.SetFloat("soundMaster", soundVolume); //string der st�r i SetFloat, skal hede det helt samme som under AudioMixer (exposed Parameters)
        
    }

    public void changeGraphicsQuality (int graphicsQuality) //graphicsQuality er int value, fordi graphics i unity har int v�rdi. Dette kan ses under project setting -> Quality
    {
        QualitySettings.SetQualityLevel(graphicsQuality);
    }

    public void ToggleFullscreen (bool checkFullscreen)
    {
        Screen.fullScreen = checkFullscreen;
    }
}
