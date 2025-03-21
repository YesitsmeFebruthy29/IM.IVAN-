using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITyrmCamera : MonoBehaviour
{
    private Camera _camera;

    // Клево, молодец
    private void Start()
    {
        _camera = Camera.main;
    }

    // пока

    private void LateUpdate()
    {
        Work();
    }


    private void Work()
    {
        transform.forward = _camera.transform.forward;
    }
}
