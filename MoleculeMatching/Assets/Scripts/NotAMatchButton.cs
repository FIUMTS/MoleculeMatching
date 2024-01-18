using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class NotAMatchButton : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject stillMolecule;
    [SerializeField] private GameObject movingMolecule;

    public static EventHandler OnNotAMatchButtonPressed;

    //TextMeshProUGUI btnText;
    [SerializeField] private GameObject NextRestartButton;

    private void OnEnable()
    {
        MatchingManager.OnMatch += SetTextCorrectOnMatch;
        //DontDestroyOnLoad(this);
    }

    private void Start()
    {

    }

    public void CompareMolecules()
    {
        //If molecules do actually match, user is wrong.
        if(stillMolecule.CompareTag("Matching"))
        {
            //fire off event
            OnNotAMatchButtonPressed?.Invoke(this, EventArgs.Empty);
            GetComponent<Button>().interactable = false;
            StartCoroutine(movingMolecule.GetComponent<InterpolateMotion>().InterpolateMolecules());
            gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Incorrect";
        }
        else if (stillMolecule.CompareTag("Not Matching")) //If molecules don't actually match, user is correct.
        {
            Debug.Log("CompareMolecules entered");
            GetComponent<Button>().interactable = false;
            NextRestartButton.GetComponent<Button>().interactable = true;
            gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Correct!";
            //StartCoroutine(movingMolecule.GetComponent<InterpolateMotion>().InterpolateMolecules());
        }
    }

    private void SetTextCorrectOnMatch(object sender, EventArgs e)
    {
        Debug.Log("SetTextCorrectOnMatch entered");
        if (stillMolecule == null)
        {
            Debug.LogError("stillMolecule is null");
            this.enabled = false;
            return;
        }
        else if (movingMolecule == null)
        {
            Debug.LogError("movingMolecule is null");
            this.enabled = false;
            return;
        }
        Debug.Log(gameObject);
        //btnText.text = "Correct!";
        gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Correct!";
        NextRestartButton.GetComponent<Button>().interactable = true;
        gameObject.GetComponent<Button>().interactable = false;
        MatchingManager.OnMatch -= SetTextCorrectOnMatch;
    }

    private void OnDestroy()
    {
        MatchingManager.OnMatch -= SetTextCorrectOnMatch;
    }



}
