using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerControls _playerControls;
    private ChargeToTarget _chargeToTarget;

    private void Awake()
    {
        _playerControls = new PlayerControls();
    }
    
    void Start()
    {
        _chargeToTarget = FindObjectOfType<ChargeToTarget>();
        _playerControls.Player.Dash.performed += ctx => OnDash();
    }

    private void OnEnable()
    {
        _playerControls.Enable();
    }

    private void OnDisable()
    {
        _playerControls.Disable();
    }

    void OnDash()
    {
        Debug.Log("123");
        _chargeToTarget.Charge();
    }
}
