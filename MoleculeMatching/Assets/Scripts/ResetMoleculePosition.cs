using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetMoleculePosition : MonoBehaviour
{
    [SerializeField]
    private GameObject molecule;



    private void Awake()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Collision");
        if (collider.CompareTag("Molecule")) {
            molecule.transform.position = new Vector2(0, 1);
        }
        
    }
}
