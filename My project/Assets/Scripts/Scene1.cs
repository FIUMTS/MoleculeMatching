using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene1 : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField] private GameObject DisplayTextBtn;
    [SerializeField] private TextMeshProUGUI exampleText;

    public void DisplayText()
    {
        exampleText.text = "Hello1";
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("SampleScene 1");
    }

    public void PreviousLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
