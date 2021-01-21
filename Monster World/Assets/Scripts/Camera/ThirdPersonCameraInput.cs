using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraInput : MonoBehaviour
{
    public CinemachineFreeLook cinemachine;

    float xAxisSpeed;
    float yAxisSpeed;

    void Start()
    {
        yAxisSpeed = cinemachine.m_YAxis.m_MaxSpeed;
        xAxisSpeed = cinemachine.m_XAxis.m_MaxSpeed;

        cinemachine.m_YAxis.m_MaxSpeed = 0;
        cinemachine.m_XAxis.m_MaxSpeed = 0;
    }

    private void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            cinemachine.m_YAxis.m_MaxSpeed = yAxisSpeed;
            cinemachine.m_XAxis.m_MaxSpeed = xAxisSpeed;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            cinemachine.m_YAxis.m_MaxSpeed = 0;
            cinemachine.m_XAxis.m_MaxSpeed = 0;
        }
    }
}
