using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal_2 : MonoBehaviour
{
    public string targetScene;
    public string startPointTag = "StartPoint";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerPrefs.SetString("SpawnPoint", startPointTag);
            SceneManager.LoadScene(targetScene);
        }
    }
}