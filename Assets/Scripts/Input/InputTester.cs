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
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Look input: " + inputManager.getLook());

        float forceMul = inputManager.getAccelerator();
        Debug.Log(forceMul);
        rigidbody.AddForce(Vector3.up * 100 * forceMul, ForceMode.Force);

    }
}
