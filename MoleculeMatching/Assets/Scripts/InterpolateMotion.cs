using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Molecule Matcher is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
 * This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
 * You should have received a copy of the GNU General Public License along with this program. If not, see <https://www.gnu.org/licenses/>.
 */

public class InterpolateMotion : MonoBehaviour
{
    [SerializeField]
    private GameObject stillMolecule;
    
    [SerializeField]
    private GameObject movingMolecule;
    
    [SerializeField]
    private GameObject helpArrow;

    private Vector3 currentPos;
    private Quaternion currentRotation;

    private MeshRenderer mrenderer;
    private MeshRenderer arrowMRenderer;

    private float duration = 0.75f;
    private float durationCenter = 2f;

    // Start is called before the first frame update
    void Start()
    {
        MatchingManager.OnMatch += Matched;
        mrenderer = movingMolecule.GetComponent<MeshRenderer>();
        if(helpArrow != null)
            arrowMRenderer = helpArrow.GetComponent<MeshRenderer>();

    }

    private void Matched(object sender, EventArgs e)
    {
        //isMatched = true;
        StartCoroutine(InterpolateMolecules());
        MatchingManager.OnMatch -= Matched;
    }

    public IEnumerator InterpolateMolecules()
    {
        currentPos = movingMolecule.transform.position;
        currentRotation = movingMolecule.transform.rotation;
        helpArrow.SetActive(false);

        float time = 0;
        if (duration > 0)
        {
            Debug.Log("Interpolation start");
            while (time < duration)
            {
                float t = time / duration;
                movingMolecule.transform.position = Vector3.Lerp(currentPos, stillMolecule.transform.position, Mathf.SmoothStep(0, 1, t));
                movingMolecule.transform.rotation = Quaternion.Slerp(currentRotation, stillMolecule.transform.rotation, Mathf.SmoothStep(0, 1, t));
                time += Time.deltaTime;
                yield return null;
            }
        }
        StartCoroutine(MoveMoleculeToMiddle());
    }

    private IEnumerator MoveMoleculeToMiddle()
    {
        //currentPos = movingMolecule.transform.position;
        //currentRotation = movingMolecule.transform.rotation;

        float time = 0;
        while (time < durationCenter)
        {
            mrenderer.enabled = false;
            float t = time / durationCenter;
            stillMolecule.transform.position = Vector3.Lerp(stillMolecule.transform.position, new Vector3(1.55f, stillMolecule.transform.position.y, stillMolecule.transform.position.z), Mathf.SmoothStep(0, 1, t));
            time += Time.deltaTime;
            yield return null;
        }
    }

    private void OnDestroy()
    {
        MatchingManager.OnMatch -= Matched;
    }
}
