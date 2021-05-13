using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private int checkpointID;

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<DriverStats>().AddCheckpoint(checkpointID);
    }
}
