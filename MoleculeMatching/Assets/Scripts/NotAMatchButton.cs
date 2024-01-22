using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

/*
 * Molecule Matcher is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
 * This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
 * You should have received a copy of the GNU General Public License along with this program. If not, see <https://www.gnu.org/licenses/>.
 */

public class NotAMatchButton : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject stillMolecule;
    [SerializeField] private GameObject movingMolecule;
    [SerializeField] private GameObject interpolationManager;

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
            StartCoroutine(interpolationManager.GetComponent<InterpolateMotion>().InterpolateMolecules());
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
