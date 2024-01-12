using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroButton : MonoBehaviour
{

    [SerializeField]
    private string title= "Title";
    private string demo = "Demo";
    public void StartDemo()
    {
        SceneManager.LoadScene(demo);
    }

    public void RestartDemo()
    {
        SceneManager.LoadScene(title);
    }
}
