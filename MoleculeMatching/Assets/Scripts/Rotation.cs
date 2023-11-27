using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


public class Rotation : MonoBehaviour
{
    private Transform MoleculeRotation;
    private bool objectIsGrabbed = false;
    private Vector3 rotation;

    private void Start()
    {
        //MoleculeRotation = GetComponent<Transform>();
    }

    public void GrabObject(InputAction.CallbackContext ctx)
    {
        if(ctx.started || ctx.performed)
        {
            Debug.Log("Object is grabbed");
            objectIsGrabbed = true;
        }
        else
        {
            objectIsGrabbed= false;
        }
    }

    public void ObjectRotation(InputAction.CallbackContext ctx)
    {
        Vector2 values = ctx.ReadValue<Vector2>();

        if (ctx.performed)
        {
            if (objectIsGrabbed)
            {
                Debug.Log(values);
                //transform.eulerAngles += new Vector3();  
            }
        }

    }
}
