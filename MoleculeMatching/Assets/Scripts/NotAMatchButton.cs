using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotAMatchButton : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject stillMolecule;
    [SerializeField] private GameObject movingMolecule;

    private Vector3 currentPos;
    private Quaternion currentRotation;

    private MeshRenderer mrenderer;

    private float timeElapsed = 0;
    private float timeElapsedCenter = 0;
    private float duration = 0.75f;
    private float durationCenter = 2f;

    private bool moleculesDoMatch = false;
    
    public void CompareMolecules()
    {
        if(stillMolecule.tag == "Matching")
        {
            movingMolecule.transform.GetChild(0).gameObject.SetActive(false);
            //moleculesDoMatch = true;
            StartCoroutine(movingMolecule.GetComponent<InterpolateMotion>().InterpolateMolecules());
        }
    }

    private void Update()
    {

    }


}
