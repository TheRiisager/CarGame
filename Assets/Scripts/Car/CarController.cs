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


    [Header("Traction Control")]
    [SerializeField] private float TCForceCut = 5;
    [SerializeField] private float TCSlipThreshold = 0.7f;

    [Header("Antiroll Bar")]
    [SerializeField] private float ARBStiffness = 5000.0f;


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
        turnRadius = wheelbase / Mathf.Sin(Mathf.Deg2Rad * steering); // This is currently used for steering!

        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {

                //Direct input steering
                //axleInfo.leftWheel.steerAngle = ackermannLeft = AckermannAngle()[0];
                //axleInfo.rightWheel.steerAngle = ackermannRight = AckermannAngle()[1];

                //Smooth steering using LERP: 
                axleInfo.leftWheel.steerAngle = ackermannLeft = Mathf.Lerp(axleInfo.leftWheel.steerAngle, AckermannAngle()[0], Time.deltaTime * turnSpeed);
                axleInfo.rightWheel.steerAngle = ackermannRight = Mathf.Lerp(axleInfo.rightWheel.steerAngle, AckermannAngle()[1], Time.deltaTime * turnSpeed);
            }

            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = axleInfo.rightWheel.motorTorque = TractionControl(motor, axleInfo.leftWheel, axleInfo.rightWheel);
                //print(axleInfo.leftWheel.motorTorque + " | " + axleInfo.rightWheel.motorTorque);
            }

            AntiRollBar(axleInfo.leftWheel, axleInfo.rightWheel); //experimental

            axleInfo.leftWheel.brakeTorque = brake;
            axleInfo.rightWheel.brakeTorque = brake;
        }
        //Debug.Log(speed);
    }

    //Antiroll bar
    private void AntiRollBar(WheelCollider wheelL, WheelCollider wheelR)
    {
        WheelHit wh = new WheelHit();

        //TODO investigate these variables. Are they supposed to be equal suspension distance on wheel colliders? 
        float travelL = 0.3f;
        float travelR = 0.3f;

        bool groundedL = wheelL.GetGroundHit(out wh);
        if (groundedL)
        {
            travelL = (wheelL.transform.InverseTransformPoint(wh.point).y - wheelL.radius) / wheelL.suspensionDistance;
        }

        bool groundedR = wheelR.GetGroundHit(out wh);
        if (groundedR)
        {
            travelR = (wheelR.transform.InverseTransformPoint(wh.point).y - wheelR.radius) / wheelR.suspensionDistance;
        }

        var antiRollForce = (travelL - travelR) * ARBStiffness;

        if (groundedL)
        {
            rigidBody.AddForceAtPosition(wheelL.transform.up * -antiRollForce, wheelL.transform.position);
        }

        if (groundedR)
        {
            rigidBody.AddForceAtPosition(wheelR.transform.up * -antiRollForce, wheelR.transform.position);
        }
    }

    //Traction control
    private float TractionControl(float force, WheelCollider wheelL, WheelCollider wheelR)
    {
        WheelHit wh = new WheelHit();

        if (wheelL.GetGroundHit(out wh))
        {
            if (wh.forwardSlip > TCSlipThreshold)
            {
                force = force / TCForceCut;
            }
        }

        if (wheelR.GetGroundHit(out wh))
        {
            if (wh.forwardSlip > TCSlipThreshold)
            {
                force = force / TCForceCut;
            }
        }
        return force;
    }

    //Ackermann steering
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
            ackermannSteering[1] = Mathf.Rad2Deg * Mathf.Atan(wheelbase / (turnRadius - (rearTrack / 2)));
            ackermannSteering[0] = Mathf.Rad2Deg * Mathf.Atan(wheelbase / (turnRadius + (rearTrack / 2)));
        }
        return ackermannSteering;
    }
    private float DecreaseSteeringWithSpeed(float speed)
    {
        return (maxSteeringAngle * inputManager.GetSteering()) / ((speed / 20) + 1);
    }




    /*
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
        }*/

}

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor; // is this wheel attached to motor?
    public bool steering; // does this wheel apply steer angle?
}
