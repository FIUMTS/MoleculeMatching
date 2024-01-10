using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideButtonOnMatch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MatchingManager.OnMatch += HideButton;
    }

    // Update is called once per frame
    private void HideButton(object sender, EventArgs e)
    {
        this.enabled = false;
        MatchingManager.OnMatch -= HideButton;
    }
}
