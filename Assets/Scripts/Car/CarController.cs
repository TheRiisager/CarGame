using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private List<AxleInfo> axleInfos;
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private float maxMotorTorque;
    [SerializeField] private float maxSteeringAngle;
    [SerializeField] private float turnSpeed;
    [SerializeField] private float maxBrakeForce;
    private InputManager inputManager;
    void Start()
    {
        inputManager = InputManager.Instance;
        rigidBody.centerOfMass = new Vector3(0, 0.1f, 0);
    }

    void FixedUpdate()
    {
        float speed = rigidBody.velocity.magnitude * 3.6f;
        float motor = maxMotorTorque * inputManager.GetAccelerator();
        float steering = DecreaseSteeringWithSpeed(speed);
        float brake = maxBrakeForce * inputManager.GetBrake();

        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = Mathf.Lerp(axleInfo.leftWheel.steerAngle, steering, Time.deltaTime * turnSpeed);
                axleInfo.rightWheel.steerAngle = Mathf.Lerp(axleInfo.leftWheel.steerAngle, steering, Time.deltaTime * turnSpeed);
            }

            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;

            }

            axleInfo.leftWheel.brakeTorque = brake;
            axleInfo.rightWheel.brakeTorque = brake;
        }
        Debug.Log(speed);
    }

    private float DecreaseSteeringWithSpeed(float speed)
    {
        return (maxSteeringAngle * inputManager.GetSteering()) / ((speed / 40) + 1);
    }

    private void SplitTorque(float motorTorque)
    {

    }

    private float[] DiffOutput(float slipLH, float slipRH, float maxSlip, float torque, float maxTrans)
    {
        float[] output = new float[2];
        float slipDifferential = slipRH - slipLH;
        float singleWheelBaseTorque = 0.5f * torque;
        float torqueTransfer = 0.0f;

        if (maxSlip != 0.0f)
        {
            if (Mathf.Abs(slipDifferential) <= Mathf.Abs(maxSlip))
            {
                torqueTransfer = slipDifferential / maxSlip;
            }
            else
            {
                torqueTransfer = 1.0f * Mathf.Sign(slipDifferential) * Mathf.Sign(maxSlip);
            }
        }
        if (Mathf.Abs(torqueTransfer) > Mathf.Abs(maxTrans))
        {
            torqueTransfer = maxTrans * Mathf.Sign(torqueTransfer);
        }
        float torqueAdjustment = singleWheelBaseTorque * torqueTransfer;
        output[0] = singleWheelBaseTorque - torqueAdjustment;
        output[1] = singleWheelBaseTorque + torqueAdjustment;
        return output;
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
