using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class ResolutionSwitch : MonoBehaviour
{
    private Toggler _inputActions;

    private readonly IReadOnlyList<float> _resolutions =
        new List<float>
        {
            1.0f,
            0.8f,
            0.6f,
            0.4f,
        }.AsReadOnly(); // Prevents modifications

    private int _currentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        _inputActions = new Toggler();
        _inputActions.Enable();

        _inputActions.Default.Next.started += NextRes;
        _inputActions.Default.Previous.started += PrevRes;
    }
    
    void NextRes(InputAction.CallbackContext ctx)
    {
        _currentIndex++;
        if (_currentIndex == _resolutions.Count)
        {
            _currentIndex = _resolutions.Count - 1;
        }
        XRSettings.eyeTextureResolutionScale = _resolutions[_currentIndex];
        Debug.Log("Resolution now: " + _resolutions[_currentIndex]);
    }

    void PrevRes(InputAction.CallbackContext ctx)
    {
        _currentIndex--;
        if (_currentIndex == -1)
        {
            _currentIndex = 0;
        }
        XRSettings.eyeTextureResolutionScale = _resolutions[_currentIndex];
        Debug.Log("Resolution now: " + _resolutions[_currentIndex]);
    }
}
