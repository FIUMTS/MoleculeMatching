using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class ViewerInputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction grabAction;
    private InputAction rotationAction;
    private InputAction panAction;
    private InputAction translationAction;

    Vector2 mousePressedPos;


    [SerializeField]
    private GameObject molecule;


    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        grabAction = playerInput.actions.FindAction("Grab");
        rotationAction = playerInput.actions.FindAction("Rotation");
        translationAction = playerInput.actions.FindAction("Translation");

        //rotateAction = playerInput.actions.FindAction("Rotate");
        panAction = playerInput.actions.FindAction("Pan");
    }

    private void OnEnable()
    {
        // += indicates subscribed, or "listening for events"
        grabAction.performed += GrabAction;
        
        //
    }

    private void OnDisable()
    {
        // -= indicates unsubscribed, or "no longer listening for events"
        grabAction.performed -= GrabAction;
        
    }

    private void GrabAction(InputAction.CallbackContext ctx)
    {
        float val = ctx.ReadValue<float>();
        if (val == 1)
        { 
            Debug.Log(val + ": Grabbed happened");
            rotationAction.performed += RotateAction;

        }
        else if (val == 0)
        {
            Debug.Log(val + ": Release happened");
            rotationAction.performed -= RotateAction;
        }
        
    }

    private void RotateAction(InputAction.CallbackContext ctx)
    {
        var axis = Quaternion.AngleAxis(-90f, Vector3.forward) * ctx.ReadValue<Vector2>(); 
        molecule.transform.rotation = Quaternion.AngleAxis(ctx.ReadValue<Vector2>().magnitude * 0.5f, axis) * molecule.transform.rotation;
        panAction.performed += PanAction;
    }

    private void MoveAction(InputAction.CallbackContext ctx)
    {
        //Vector2 newPos = new Vector2(ctx.ReadValue(Vector2).x * 0.01f, Mouse.current.position.ReadValue().y * 0.01f) * molecule.transform.position;
        rotationAction.performed -= RotateAction;
        Vector2 newPos = new Vector2(ctx.ReadValue<Vector2>().x + molecule.transform.position.x, ctx.ReadValue<Vector2>().y + molecule.transform.position.y);
        molecule.transform.position = newPos;
        Debug.Log(ctx.ReadValue<Vector2>());
    }

    private void PanAction(InputAction.CallbackContext ctx)
    {
        float val = ctx.ReadValue<float>();
        if (val == 1)
        {
            Debug.Log(val + ": Panning...");
            translationAction.performed += MoveAction;

        }
        else if (val == 0)
        {
            Debug.Log(val + ": Panning stopped");
            translationAction.performed -= MoveAction;
            rotationAction.performed += RotateAction;
        }
    }
}
