using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio; //Importing Unity sound package, so we with scripts can manipulate with unitys AudioMixer
using UnityEngine.UI; //Gør at vi kan tilgå elementer i UI
public class settingsMenuHandler : MonoBehaviour

   
{
    public AudioMixer soundMixer;

    public TMPro.TMP_Dropdown resolutionSelecter;
    Resolution[] resolutions; //arraylist som gemmer brugerens skærm resolutions

    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutionSelecter.ClearOptions(); //Sletter options i vores resolution dropdown menu, så vi kan tilføje vores egne options via nedenstående:

        List<string> options = new List<string>(); //Vi laver denne som List, da vi skal gemme værdierne fra Arraylist Resolution[] resolutions, som en string list istedet. List har ingen fixed size, ligesom ArrayList
        int preselectedResolution = 0; //Bruges til at sætte brugers nuværende skærm resolution til default i dropdown menu 

        for (int i = 0; i < resolutions.Length; i++) //Dette loop tilføjer alle skærm resolutions bruger har til dropdown listen
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height) //Tjekker om resolution i array der kigges på == brugers nuværende resolutin
            {
                preselectedResolution = i; //Gemmer hvilket index i array, som brugers nuværende resolutin er på
            }
        }
        resolutionSelecter.AddOptions(options);
        resolutionSelecter.value = preselectedResolution;
        resolutionSelecter.RefreshShownValue();
        //Ovenstående 3, måske man kan gøre det smartere i de nyere versioner af unity?

    }
    public void ChangeResolution (int preselectedResolution)
    {
        Resolution resolution = resolutions[preselectedResolution];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void changeSoundVolume(float soundVolume)
    {
        soundMixer.SetFloat("soundMaster", soundVolume); //string der står i SetFloat, skal hede det helt samme som under AudioMixer (exposed Parameters)
        
    }

    public void changeGraphicsQuality (int graphicsQuality) //graphicsQuality er int value, fordi graphics i unity har int værdi. Dette kan ses under project setting -> Quality
    {
        QualitySettings.SetQualityLevel(graphicsQuality);
    }

    public void ToggleFullscreen (bool checkFullscreen)
    {
        Screen.fullScreen = checkFullscreen;
    }
}
