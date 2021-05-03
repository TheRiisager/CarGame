using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTester : MonoBehaviour
{
    InputManager inputManager;
    Rigidbody rg;

    void Start()
    {
        inputManager = InputManager.Instance;
        rg = GetComponent<Rigidbody>();
        
    }

    //Use OnEnable to subscribe to events
    void OnEnable()
    {
        //Events are static, so they don't need a reference to an instance of InputManager
        InputManager.MenuButtonEvent += LogMenu;
        InputManager.ResetButtonEvent += LogReset;
    }

    //Make sure to unsubscribe from events on disable.
    void OnDisable()
    {
        InputManager.MenuButtonEvent -= LogMenu;
        InputManager.ResetButtonEvent -= LogReset;
    }

    void Update()
    {
        Debug.Log(inputManager.GetAccelerator());
        float forceMul = inputManager.GetAccelerator();
        rg.AddForce(Vector3.up * 100 * forceMul, ForceMode.Force);

    }

    void LogMenu()
    {
        Debug.Log("MENU!");
    }

    void LogReset()
    {
        Debug.Log("RESET!");
    }
}
