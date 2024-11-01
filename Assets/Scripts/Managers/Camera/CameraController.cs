using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform _target = null;
    private Cinemachine.CinemachineVirtualCamera cinVirtCam;

    private void Awake()
    {
        cinVirtCam = GetComponent<Cinemachine.CinemachineVirtualCamera>();
    }
    private void Update()
    {
        if (_target)
        {
            cinVirtCam.Follow = _target;
            
        }
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }
}
