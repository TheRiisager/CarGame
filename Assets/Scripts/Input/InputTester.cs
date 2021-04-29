using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTester : MonoBehaviour
{
    InputManager inputManager;
    Rigidbody rigidbody;

    void Start()
    {
        inputManager = InputManager.Instance;
        rigidbody = GetComponent<Rigidbody>();
        inputManager.MenuButtonEvent += LogMenu;
        inputManager.ResetButtonEvent += LogReset;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Look input: " + inputManager.getLook());

        float forceMul = inputManager.GetAccelerator();
        rigidbody.AddForce(Vector3.up * 100 * forceMul * Time.deltaTime, ForceMode.Acceleration);

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
