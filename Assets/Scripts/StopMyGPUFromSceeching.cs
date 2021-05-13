using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMyGPUFromSceeching : MonoBehaviour
{
    void Awake()
    {
        Application.targetFrameRate = 144;
    }
}
