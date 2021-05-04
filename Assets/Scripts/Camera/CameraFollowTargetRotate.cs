using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTargetRotate : MonoBehaviour
{
    [SerializeField] private float verticalCameraSpeed = 20.0f;
    [SerializeField] private float horizontalCameraSpeed = 20.0f;
    [SerializeField] private float cameraClampAngle = 90.0f;
    private Vector2 deltaInput;
    private Vector3 startingRotation;
    private InputManager inputManager;
    // Start is called before the first frame update
    void Start()
    {
        inputManager = InputManager.Instance;
        startingRotation = transform.localRotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        deltaInput = inputManager.GetLook();
        startingRotation.x += deltaInput.x * verticalCameraSpeed * Time.deltaTime;
        startingRotation.y += deltaInput.y * horizontalCameraSpeed * Time.deltaTime;
        startingRotation.y = Mathf.Clamp(startingRotation.y, -cameraClampAngle, cameraClampAngle);
        transform.rotation = Quaternion.Euler(-startingRotation.y, startingRotation.x, 0f);
    }
}
