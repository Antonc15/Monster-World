using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ThirdPersonCameraInput : MonoBehaviour
{
    public CinemachineFreeLook cinemachine;

    float xAxisSpeed;
    float yAxisSpeed;
    CustomCursor cursor;

    void Start()
    {
        yAxisSpeed = cinemachine.m_YAxis.m_MaxSpeed;
        xAxisSpeed = cinemachine.m_XAxis.m_MaxSpeed;
        cursor = GameObject.FindGameObjectWithTag("Cursor").GetComponent<CustomCursor>();
    }

    void Update()
    {
        HideCursor();
        CameraLook();
    }

    void HideCursor()
    {
        if (Cursor.visible)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    void CameraLook()
    {
        if (Input.GetButton("Fire2"))
        {
            cursor.looking = true;

            cinemachine.m_YAxis.m_MaxSpeed = yAxisSpeed;
            cinemachine.m_XAxis.m_MaxSpeed = xAxisSpeed;
        }
        else
        {
            cursor.looking = false;

            cinemachine.m_YAxis.m_MaxSpeed = 0;
            cinemachine.m_XAxis.m_MaxSpeed = 0;
        }
    }
}
