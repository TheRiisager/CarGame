using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelVisualizer : MonoBehaviour
{

    [SerializeField]
    private WheelCollider wc;

    Vector3 pos;
    Quaternion rot;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        wc.GetWorldPose(out pos, out rot);
        transform.position = pos;
        transform.rotation = rot;

    }
}
