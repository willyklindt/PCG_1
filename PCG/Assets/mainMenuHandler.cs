using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Unity library that allows us to manipulate with scenes

public class mainMenuHandler : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene("SampleScene"); //Loads our scene, "SampleScene" when this methods gets called
    }

    public void exitGame()
    {
        Application.Quit();
        Debug.Log("Game has been exited (doesn't work in Unity editor mode");
    }
}
