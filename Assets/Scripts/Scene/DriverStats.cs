using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverStats : MonoBehaviour
{
    private List<int> ClearedCheckpoints;

    void Awake()
    {
        ClearedCheckpoints = new List<int>();
    }

    public void AddCheckpoint(int checkpointID)
    {
        if(ClearedCheckpoints.Contains(checkpointID))
        {
            return;
        }

        Debug.Log("added checkpoint");
        ClearedCheckpoints.Add(checkpointID);
        Debug.Log(ClearedCheckpoints);
    }
}
