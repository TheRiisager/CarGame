using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;
    public GameObject object4;
    public GameObject object5;
    public GameObject object6;
    int xPos;
    int zPos;
    float yPos;
    int objectToGenerate;
    int objectCount = 0;
    public int AmountOfObjects = 0;

    public void GenerateAmountOfObjects()
    {
        for (int i = 0; i < AmountOfObjects; i++)
        {
            objectToGenerate = Random.Range(1, 7);
            xPos = Random.Range(1, 512);
            zPos = Random.Range(1, 512);
            yPos = Terrain.activeTerrain.SampleHeight(new Vector3(xPos, 0, zPos));
            if (objectToGenerate == 1)
            {
                Instantiate(object1, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            }
            if (objectToGenerate == 2)
            {
                Instantiate(object2, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            }
            if (objectToGenerate == 3)
            {
                Instantiate(object3, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            }
            if (objectToGenerate == 4)
            {
                Instantiate(object4, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            }
            if (objectToGenerate == 5)
            {
                Instantiate(object5, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            }
            if (objectToGenerate == 6)
            {
                Instantiate(object6, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            }

        }

    }

    public void GenerateObjects()
    {
        while (objectCount < Random.Range(300, 700))
        {
            objectToGenerate = Random.Range(1, 7);
            xPos = Random.Range(1, 512);
            zPos = Random.Range(1, 512);
            yPos = Terrain.activeTerrain.SampleHeight(new Vector3(xPos, 0, zPos));
            if (objectToGenerate == 1)
            {
                Instantiate(object1, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            }
            if (objectToGenerate == 2)
            {
                Instantiate(object2, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            }
            if (objectToGenerate == 3)
            {
                Instantiate(object3, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            }
            if (objectToGenerate == 4)
            {
                Instantiate(object4, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            }
            if (objectToGenerate == 5)
            {
                Instantiate(object5, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            }
            if (objectToGenerate == 6)
            {
                Instantiate(object6, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            }
            objectCount += 1;
        }
        objectCount = 0;
    }
}