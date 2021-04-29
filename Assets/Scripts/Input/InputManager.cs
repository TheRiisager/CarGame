using System.Collections;
using System.Collections.Generic;
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

    public Vector2 getLook()
    {
        return controls.Car.Look.ReadValue<Vector2>();
    }

    public float getSteering()
    {
        return controls.Car.Steering.ReadValue<float>();
    }

    public float getAccelerator()
    {
        return controls.Car.Accelerator.ReadValue<float>();
    }

    public float getBrake()
    {
        return controls.Car.Brake.ReadValue<float>();
    }

    public bool getMenuButton()
    {
        return controls.Car.Menu.triggered;
    }

    public bool getResetButton()
    {
        return controls.Car.Reset.triggered;
    }



}