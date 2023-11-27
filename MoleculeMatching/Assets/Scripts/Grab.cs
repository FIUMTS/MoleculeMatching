using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Grab : MonoBehaviour
{
    // Start is called before the first frame update
    private CinemachineFreeLook freeLook;

    private void Start()
    {
        freeLook = GetComponent<CinemachineFreeLook>();
        freeLook.m_XAxis.m_InputAxisName = "";
        freeLook.m_YAxis.m_InputAxisName = "";
    }

    public void GrabObject(InputAction.CallbackContext ctx)
    {
        if(ctx.started)
        {
            Debug.Log("Object Grabbed");
            freeLook.m_XAxis.m_InputAxisName = "Mouse X";
            freeLook.m_YAxis.m_InputAxisName = "Mouse Y";
        }
        else if(ctx.canceled)
        {
            freeLook.m_XAxis.m_InputAxisName = "";
            freeLook.m_XAxis.m_InputAxisValue = 0;
            freeLook.m_YAxis.m_InputAxisName = "";
            freeLook.m_YAxis.m_InputAxisValue = 0;
        }

    }
}
