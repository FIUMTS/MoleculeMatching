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
        
    }
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Wall"))
        {
            //transform.position = new Vector3(0, 1, 0);

        }
        
    }
}
