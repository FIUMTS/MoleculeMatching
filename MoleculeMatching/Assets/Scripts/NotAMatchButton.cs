using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class NotAMatchButton : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject stillMolecule;
    [SerializeField] private GameObject movingMolecule;

    public static EventHandler OnNotAMatchButtonPressed;

    TextMeshProUGUI btnText;
    [SerializeField] private GameObject NextRestartButton;

    private void OnEnable()
    {
        btnText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        MatchingManager.OnMatch += SetTextCorrectOnMatch;
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
            btnText.text = "Incorrect";
        }
        else if (stillMolecule.CompareTag("Not Matching")) //If molecules don't actually match, user is correct.
        {
            Debug.Log("CompareMolecules entered");
            GetComponent<Button>().interactable = false;
            NextRestartButton.GetComponent<Button>().interactable = true;
            btnText.text = "Correct!";
            //StartCoroutine(movingMolecule.GetComponent<InterpolateMotion>().InterpolateMolecules());
        }
    }

    private void SetTextCorrectOnMatch(object sender, EventArgs e)
    {
        Debug.Log("SetTextCorrectOnMatch entered");
        btnText.text = "Correct!";
        NextRestartButton.GetComponent<Button>().interactable = true;
        gameObject.GetComponent<Button>().interactable = false;
        MatchingManager.OnMatch -= SetTextCorrectOnMatch;
    }



}
