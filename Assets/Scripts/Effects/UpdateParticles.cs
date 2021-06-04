using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class UpdateParticles : MonoBehaviour
{
    [SerializeField] float particleCutoffVelocity = 1;
    VisualEffect[] vfx;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        vfx = GetComponentsInChildren<VisualEffect>();
    }
    void Update()
    {
        Vector3 velocity = rb.velocity;
        foreach(VisualEffect fx in vfx)
        {
            fx.SetFloat("ExitVelocity", velocity.magnitude * 0.5f);
            if(velocity.magnitude <= particleCutoffVelocity)
            {
                fx.enabled = false;
            } else
            {
                fx.enabled = true;
            }
        }
    }
}
