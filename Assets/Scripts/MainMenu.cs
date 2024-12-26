using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }

    // public void Options()
    // {
    //     SceneManager.LoadScene("OptionsMenu");
    // }
    public void Quit ()
    {
        Application.Quit();
        Debug.Log("Player Has Quit The Game");
    }
}
