using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterpolateMotion : MonoBehaviour
{
    [SerializeField]
    private GameObject stillMolecule;

    private Vector3 currentPos;
    private Quaternion currentRotation;

    private MeshRenderer mrenderer;

    private float timeElapsed = 0;
    private float timeElapsedCenter = 0;
    private float duration = 1f;
    private float durationCenter = 3f;
    private bool isMatched;

    // Start is called before the first frame update
    void Start()
    {
        MatchingManager.OnMatch += Matched;
        mrenderer = GetComponent<MeshRenderer>();
    }

    private void Matched(object sender, EventArgs e)
    {
        isMatched = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMatched)
        {
            currentPos = transform.position;
            currentRotation = transform.rotation;
            if (timeElapsed < duration)
            {
                float t = timeElapsed / duration;
                transform.position = Vector3.Lerp(currentPos, stillMolecule.transform.position, Mathf.SmoothStep(0, 1, t));
                transform.rotation = Quaternion.Slerp(currentRotation, stillMolecule.transform.rotation, Mathf.SmoothStep(0, 1, t));
                timeElapsed += Time.deltaTime;
            }
            else
            {
                Debug.Log("Move to center");
                mrenderer.enabled = false;
                float t = timeElapsedCenter / durationCenter;
                stillMolecule.transform.position = Vector3.Lerp(stillMolecule.transform.position, new Vector3(1.55f, stillMolecule.transform.position.y, stillMolecule.transform.position.z), Mathf.SmoothStep(0, 1, t));
                timeElapsedCenter += Time.deltaTime;
            }
        }
    }
}
