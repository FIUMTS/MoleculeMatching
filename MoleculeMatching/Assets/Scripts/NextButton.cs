using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextButton : MonoBehaviour
{

    private void OnEnable()
    {
        MatchingManager.OnMatch += Next;
    }

    private void Next(object sender, EventArgs e)
    {
        GetComponent<Button>().interactable = true;
    }

    public void NextDemo()
    {
        SceneManager.LoadScene("Demo 2");
    }

    public void RestartDemo()
    {
        SceneManager.LoadScene("Title");
    }

    public void ResetScene()
    {
        string currScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currScene);
    }

}
