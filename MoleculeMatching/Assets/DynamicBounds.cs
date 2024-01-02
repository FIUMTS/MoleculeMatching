using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DynamicBounds : MonoBehaviour
{
    // Update is called once per frame
    Collider boxCollider;

    private void Awake()
    {
        boxCollider = GetComponent<Collider>();
    }
    void Update()
    {
        //boxCollider.
    }
}
