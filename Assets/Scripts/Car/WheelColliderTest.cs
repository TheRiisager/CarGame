using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelColliderTest : MonoBehaviour
{
    [SerializeField] private List<AxleInfo> axleInfos;
    [SerializeField] private float maxMotorTorque;
    [SerializeField] private float maxSteeringAngle;
    [SerializeField] private float maxBrakeForce;
    private InputManager inputManager;
    void Start()
    {
        inputManager = InputManager.Instance;
    }

    void FixedUpdate()
    {
        float motor = maxMotorTorque * inputManager.GetAccelerator();
        float steering = maxSteeringAngle * inputManager.GetSteering();
        float brake = maxBrakeForce * inputManager.GetBrake();

        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }

            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
            
            axleInfo.leftWheel.brakeTorque = brake;
            axleInfo.rightWheel.brakeTorque = brake;
        }
    }
}

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor; // is this wheel attached to motor?
    public bool steering; // does this wheel apply steer angle?
}
