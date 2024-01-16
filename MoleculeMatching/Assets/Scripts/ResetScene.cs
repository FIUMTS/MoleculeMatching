using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{
    public void ResetSceneButton()
    {
        string currScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currScene);
    }
}
