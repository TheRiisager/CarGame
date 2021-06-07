using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class UpdateParticles : MonoBehaviour
{
    [SerializeField] float particleCutoffVelocity = 1;
    VisualEffect[] vfx;
    Rigidbody rb;
    [SerializeField] float tireTrackThreshold = 2f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        vfx = GetComponentsInChildren<VisualEffect>();
    }
    void FixedUpdate()
    {
        Vector3 velocity = rb.velocity;
        float localXVelocity = Mathf.Abs( transform.InverseTransformDirection(velocity).x );
        foreach(VisualEffect fx in vfx)
        {
            if(fx.GetInt("id") == 1)
            {
                fx.SetFloat("ExitVelocity", velocity.magnitude * 0.5f);
                if(velocity.magnitude <= particleCutoffVelocity)
                {
                    fx.SetInt("spawnrate", 0);
                } else
                {
                    fx.SetInt("spawnrate", 50);
                }
            }

            if(fx.GetInt("id") == 2)
            {
                if(localXVelocity >= tireTrackThreshold)
                {
                    fx.SetInt("spawnrate", 128);
                } else
                {
                    fx.SetInt("spawnrate", 0);
                }
            }
        }
    }
}
