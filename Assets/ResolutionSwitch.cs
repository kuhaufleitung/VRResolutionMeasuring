using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using Random = UnityEngine.Random;

public class ResolutionSwitch : MonoBehaviour
{
    private Toggler _inputActions;
    [SerializeField]
    private TextMeshPro text;

    [SerializeField] private float stepSize;
    private float _currentRes = 1.0f;

    private void FixedUpdate()
    {
        if (_inputActions.Default.UpRes.IsPressed())
        {
            CalcClampedResScale(stepSize);
            XRSettings.eyeTextureResolutionScale = _currentRes;
            Debug.Log("Resolution scale now: " + _currentRes);
        } else if (_inputActions.Default.LowerRes.IsPressed())
        {
            CalcClampedResScale(-stepSize);
            XRSettings.eyeTextureResolutionScale = _currentRes;
            Debug.Log("Resolution scale now: " + _currentRes);
        }
    }

    void Start()
    {
        var rngNumber = Random.Range(1000000.0f, 9999999.0f);
        var nbr = (int)rngNumber;
        text.SetText(nbr.ToString());
        _inputActions = new Toggler();
        _inputActions.Enable();

        _inputActions.Default.NewNumber.started += SetNewNumber;
    }
    
    private void SetNewNumber(InputAction.CallbackContext ctx)
    {
        var rngNumber = Random.Range(1000000.0f, 9999999.0f);
        var nbr = (int)rngNumber;
        text.SetText(nbr.ToString());
    }

    private void CalcClampedResScale(float scaleStep)
    {
        _currentRes += scaleStep;
        if (_currentRes < 0.01f)
        {
            _currentRes = 0.01f;
        }
        else if (_currentRes > 1.0f)
        {
            _currentRes = 1.0f;
        }
        else
        {
            _currentRes += scaleStep;
        }
    }
}
