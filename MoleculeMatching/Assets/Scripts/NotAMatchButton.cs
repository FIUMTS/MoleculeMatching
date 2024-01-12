using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotAMatchButton : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject stillMolecule;
    [SerializeField] private GameObject movingMolecule;

    //private bool moleculesDoMatch = false;
    
    public void CompareMolecules()
    {
        //If molecules do actually match, user is wrong.
        if(stillMolecule.tag == "Matching")
        {
            GetComponent<Button>().interactable = false;
            movingMolecule.transform.GetChild(0).gameObject.SetActive(false);
            StartCoroutine(movingMolecule.GetComponent<InterpolateMotion>().InterpolateMolecules());
        }
        else if (stillMolecule.tag == "Not Matching") //If molecules don't actually match, user is correct.
        {
            gameObject.SetActive(false);

            movingMolecule.transform.GetChild(0).gameObject.SetActive(false);
            StartCoroutine(movingMolecule.GetComponent<InterpolateMotion>().InterpolateMolecules());
        }
    }



}
