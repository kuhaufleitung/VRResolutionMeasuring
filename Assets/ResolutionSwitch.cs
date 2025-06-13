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

    private readonly IReadOnlyList<float> _resolutions =
        new List<float>
        {
            1.0f,
            0.8f,
            0.6f,
            0.4f,
            0.2f
        }.AsReadOnly(); // Prevents modifications

    private int _currentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        var rngNumber = Random.Range(10.0f, 99.0f);
        var nbr = (int)rngNumber;
        text.SetText(nbr.ToString());
        _inputActions = new Toggler();
        _inputActions.Enable();

        _inputActions.Default.Next.started += NextRes;
        _inputActions.Default.Previous.started += PrevRes;
        _inputActions.Default.NewNumber.started += SetNewNumber;
    }
    
    private void NextRes(InputAction.CallbackContext ctx)
    {
        _currentIndex++;
        if (_currentIndex == _resolutions.Count)
        {
            _currentIndex = _resolutions.Count - 1;
        }
        XRSettings.eyeTextureResolutionScale = _resolutions[_currentIndex];
        Debug.Log("Resolution now: " + _resolutions[_currentIndex]);
    }

    private void PrevRes(InputAction.CallbackContext ctx)
    {
        _currentIndex--;
        if (_currentIndex == -1)
        {
            _currentIndex = 0;
        }
        XRSettings.eyeTextureResolutionScale = _resolutions[_currentIndex];
        Debug.Log("Resolution now: " + _resolutions[_currentIndex]);
    }

    private void SetNewNumber(InputAction.CallbackContext ctx)
    {
        var rngNumber = Random.Range(10.0f, 99.0f);
        var nbr = (int)rngNumber;
        text.SetText(nbr.ToString());
    }
}
