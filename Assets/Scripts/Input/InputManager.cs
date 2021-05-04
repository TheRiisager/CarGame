using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance
    {
        get
        {
            return instance;
        }
    }
    private Controls controls;

    //Events are static, so they don't need a reference to an instance of InputManager
    public static event Action MenuButtonEvent;
    public static event Action ResetButtonEvent;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        controls = new Controls();
    }
    
    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    void Update()
    {
        if(GetMenuButton()) MenuButtonEvent?.Invoke();
        if(GetResetButton()) ResetButtonEvent?.Invoke();
    }

    public Vector2 GetLook()
    {
        return controls.Car.Look.ReadValue<Vector2>();
    }

    public float GetSteering()
    {
        return controls.Car.Steering.ReadValue<float>();
    }

    public float GetAccelerator()
    {
        return controls.Car.Accelerator.ReadValue<float>();
    }

    public float GetBrake()
    {
        return controls.Car.Brake.ReadValue<float>();
    }

    public bool GetMenuButton()
    {
        return controls.Car.Menu.triggered;
    }

    public bool GetResetButton()
    {
        return controls.Car.Reset.triggered;
    }



}