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

    private Vector3 currentPos;
    private Quaternion currentRotation;

    private MeshRenderer mrenderer;

    private float timeElapsed = 0;
    private float timeElapsedCenter = 0;
    private float duration = 0.75f;
    private float durationCenter = 2f;
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
