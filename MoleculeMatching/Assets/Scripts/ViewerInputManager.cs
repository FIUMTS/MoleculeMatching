using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

/*
 * Molecule Matcher is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
 * This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
 * You should have received a copy of the GNU General Public License along with this program. If not, see <https://www.gnu.org/licenses/>.
 */

public class ViewerInputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction grabAction;
    private InputAction rotationAction;
    private InputAction panAction;
    private InputAction translationAction;


    [SerializeField]
    private GameObject molecule;
    [SerializeField]
    private GameObject moleculeBox;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();

        grabAction = playerInput.actions.FindAction("Grab");
        rotationAction = playerInput.actions.FindAction("Rotation");
        translationAction = playerInput.actions.FindAction("Translation");
        panAction = playerInput.actions.FindAction("Pan");

    }


    private void FreezeControls(object sender, EventArgs e)
    {
        Debug.Log("Freeze");
        grabAction.performed -= GrabAction;
        rotationAction.performed -= RotateAction;
        translationAction.performed -= MoveAction;
        panAction.performed -= PanAction;
    }

    private void OnEnable()
    {
        // += indicates subscribed, or "listening for events"
        grabAction.performed += GrabAction;
        MatchingManager.OnMatch += FreezeControls;
    }

    private void OnDisable()
    {
        // -= indicates unsubscribed, or "no longer listening for events"
        grabAction.performed -= GrabAction;

    }

    private void GrabAction(InputAction.CallbackContext ctx)
    {
        Debug.Log("Grabbed");
        float val = ctx.ReadValue<float>();
        if (val == 1)
        {
            //Debug.Log(val + ": Grabbed happened");
            rotationAction.performed += RotateAction;
            translationAction.performed -= MoveAction;
        }
        else if (val == 0)
        {
            //Debug.Log(val + ": Release happened");
            rotationAction.performed -= RotateAction;
            translationAction.performed -= MoveAction;
        }

    }

    private void RotateAction(InputAction.CallbackContext ctx)
    {
        Debug.Log("Rotate");
        var axis = Quaternion.AngleAxis(-90f, Vector3.forward) * ctx.ReadValue<Vector2>();
        molecule.transform.rotation = Quaternion.AngleAxis(ctx.ReadValue<Vector2>().magnitude * 0.5f, axis) * molecule.transform.rotation;
        panAction.performed += PanAction;
    }

    private void MoveAction(InputAction.CallbackContext ctx)
    {

        rotationAction.performed -= RotateAction;
        Vector2 newPos = new(ctx.ReadValue<Vector2>().x + moleculeBox.transform.position.x, ctx.ReadValue<Vector2>().y + moleculeBox.transform.position.y);
        moleculeBox.transform.position = newPos;
        //Debug.Log(ctx.ReadValue<Vector2>());
    }

    private void PanAction(InputAction.CallbackContext ctx)
    {
        float val = ctx.ReadValue<float>();
        if (val == 1)
        {
            //Debug.Log(val + ": Panning...");
            translationAction.performed += MoveAction;
            rotationAction.performed -= RotateAction;

        }
        else if (val == 0)
        {
            // Debug.Log(val + ": Panning stopped");
            translationAction.performed -= MoveAction;
            //rotationAction.performed += RotateAction;
        }
    }

    public void EnableMouse()
    {
        playerInput.SwitchCurrentActionMap("Mouse");
        //playerInput.actions.FindActionMap("Mouse").Enable();
        //playerInput.actions.FindActionMap("Touch").Disable();
    }

    public void EnableTouch()
    {
        //playerInput.SwitchCurrentActionMap("Touch");

        playerInput.SwitchCurrentActionMap("Touch");
        //playerInput.actions.FindActionMap("Touch").Enable();
        //playerInput.actions.FindActionMap("Mouse").Disable();
    }

    private void OnDestroy()
    {
        Debug.Log("Viewer Input Manager Destroyed");
        grabAction.performed -= GrabAction;
        rotationAction.performed -= RotateAction;
        translationAction.performed -= MoveAction;
        panAction.performed -= PanAction;
        MatchingManager.OnMatch -= FreezeControls;
    }
}