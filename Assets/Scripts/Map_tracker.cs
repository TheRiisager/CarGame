using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Map_tracker : MonoBehaviour
{

    private GameObject cp;
    private Transform cp_start, cp_child, cp_spawnpoint, cp_direction, car_body;
    private bool readyToEnd;
    private float t_start;
    private int t_final;

    private string p_name, file;
    [SerializeField] string file_reference;

    private int cp_numberTotal, cp_numberCurrent;

    void Start()
    {
        cp = GameObject.Find("Checkpoints");
        cp_start = cp.transform.GetChild(0);

        car_body = GameObject.Find("PlayerCar").transform.GetChild(0);

        readyToEnd = false;
        p_name = "Player";
        file = Application.dataPath + ("/Resources/" + file_reference + ".txt");

        Set_cp_numberTotal();
        Reset_cp_numberCurrent();
        Set_cp_child();
    }

    void OnEnable()
    {
        InputManager.ResetButtonEvent += ResetCar;
    }

    void OnDisable()
    {
        InputManager.ResetButtonEvent -= ResetCar;
    }


    void ResetCar()
    {
        car_body.GetComponent<Rigidbody>().velocity = Vector3.zero;
        car_body.transform.position = cp_child.GetChild(0).position;
        car_body.LookAt(cp_direction);
    }

    void OnTriggerEnter(Collider c)
    {
        //starting the game
        if (c.gameObject.name.Equals("Checkpoint 0") && !readyToEnd)
        {

            t_start = Time.time;
        }

        //ending the game
        if (c.gameObject.name.Equals("Checkpoint 0") && readyToEnd)
        {
            Debug.Log("Finale time pre int: " + (Time.time - t_start));
            t_final = Mathf.RoundToInt((Time.time - t_start) * 1000);
            Debug.Log("Finale time post int: " + t_final);
            string line = p_name + " " + t_final + "\n";
            Debug.Log(line);
            Debug.Log(file);
            File.AppendAllText(file, line);

        }
    }
    void OnTriggerExit(Collider c)
    {
        if (cp_numberCurrent == cp_numberTotal && c.gameObject.name.Equals("Checkpoint 0"))
        {
            Reset_cp_numberCurrent();
        }

        if (c.gameObject.name.Equals("Checkpoint " + (cp_numberCurrent + 1)))
        {
            Debug.Log(cp_numberCurrent);
            Advance_cp_numberCurrent();
            Debug.Log(cp_numberCurrent);
        }

        if (cp_numberCurrent == cp_numberTotal)
        {
            readyToEnd = true;
        }

        Set_cp_child();
    }
    void Advance_cp_numberCurrent()
    {
        cp_numberCurrent++;
    }
    void Reset_cp_numberCurrent()
    {
        cp_numberCurrent = 0;

    }
    void Set_cp_child()
    {
        cp_child = cp.transform.GetChild(cp_numberCurrent);
        cp_spawnpoint = cp_child.GetChild(0);
        cp_direction = cp_child.GetChild(1);
    }
    void Set_cp_numberTotal()
    {
        cp_numberTotal = cp.transform.childCount - 1;
    }
}
