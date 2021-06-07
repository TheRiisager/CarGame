using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private List<AxleInfo> axleInfos;
    [SerializeField] private Rigidbody rigidBody;

    [Header("Steering")]
    [SerializeField] private float maxSteeringAngle;
    [SerializeField] private float turnSpeed;
    [SerializeField] private float steering;
    [SerializeField] private float ackermannLeft;
    [SerializeField] private float ackermannRight;

    [Header("Wheels")]
    [SerializeField] private GameObject frontLeft;
    [SerializeField] private GameObject frontRight;
    [SerializeField] private GameObject rearLeft;
    [SerializeField] private GameObject rearRight;
    [SerializeField] private float wheelbase;
    [SerializeField] private float rearTrack;
    [SerializeField] private float turnRadius;


    [Header("Motor")]
    [SerializeField] private float maxMotorTorque;
    [SerializeField] private float maxBrakeForce;

    [Header("Differential NOT IN USE")]


    private InputManager inputManager;
    void Start()
    {
        inputManager = InputManager.Instance;
        rigidBody.centerOfMass = new Vector3(0, 0.1f, 0); //Overwriting the center of mass, for better handling.
        wheelbase = Vector3.Distance(frontLeft.transform.position, rearLeft.transform.position);
        rearTrack = Vector3.Distance(rearRight.transform.position, rearLeft.transform.position);
    }

    void FixedUpdate()
    {
        float speed = rigidBody.velocity.magnitude * 3.6f;
        float motor = maxMotorTorque * inputManager.GetAccelerator();
        float brake = maxBrakeForce * inputManager.GetBrake();
        steering = DecreaseSteeringWithSpeed(speed); //Bugged
        turnRadius = wheelbase / Mathf.Sin(maxSteeringAngle * -inputManager.GetSteering()); // This is currently used for steering!
        //TODO Decreased steering with speed, introduces a bug when used with ackermannsteering
        //turnRadius = wheelbase / Mathf.Sin((180 - steering) * inputManager.GetSteering());

        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                //axleInfo.leftWheel.steerAngle = ackermannLeft = AckermannAngle()[0];
                //axleInfo.rightWheel.steerAngle = ackermannRight = AckermannAngle()[1];

                //Smooth steering using LERP: 
                axleInfo.leftWheel.steerAngle = ackermannLeft = Mathf.Lerp(axleInfo.leftWheel.steerAngle, AckermannAngle()[0], Time.deltaTime * turnSpeed);
                axleInfo.rightWheel.steerAngle = ackermannRight = Mathf.Lerp(axleInfo.leftWheel.steerAngle, AckermannAngle()[1], Time.deltaTime * turnSpeed);
            }

            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }

            axleInfo.leftWheel.brakeTorque = brake;
            axleInfo.rightWheel.brakeTorque = brake;
        }
        //Debug.Log(speed);
    }

    private float[] AckermannAngle()
    {
        //Index 0 = Left wheel  |  Index 1 = Right wheel
        float[] ackermannSteering = { 0, 0 };
        if (steering > 0)
        {
            ackermannSteering[0] = Mathf.Rad2Deg * Mathf.Atan(wheelbase / (turnRadius + (rearTrack / 2)));
            ackermannSteering[1] = Mathf.Rad2Deg * Mathf.Atan(wheelbase / (turnRadius - (rearTrack / 2)));
        }
        else if (steering < 0)
        {
            ackermannSteering[0] = Mathf.Rad2Deg * Mathf.Atan(wheelbase / (turnRadius - (rearTrack / 2)));
            ackermannSteering[1] = Mathf.Rad2Deg * Mathf.Atan(wheelbase / (turnRadius + (rearTrack / 2)));
        }
        return ackermannSteering;
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
