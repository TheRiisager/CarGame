using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    [SerializeField] Rigidbody filmedObject;
    [SerializeField] GameObject SlowCam;
    [SerializeField] GameObject FastCam;
    [SerializeField][Tooltip("Velocity at which camera switches from slow to fast cam")] private float SwitchVelocity;
    private float velocity;


    void Update()
    {
        velocity = filmedObject.velocity.magnitude;

        if(velocity >= SwitchVelocity)
        {
            FastCam.SetActive(true);
            SlowCam.SetActive(false);
        } else
        {
            FastCam.SetActive(false);
            SlowCam.SetActive(true);
        }
    }

}
