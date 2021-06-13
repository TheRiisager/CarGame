using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public int noiseDepth;
    int width = 512;
    int height = 512;
    public float noiseScale = 20f;
    public float noisePosX = 100f;
    public float noisePosY = 100f;

    public TerrainData GenerateTerrain()
    {
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData.size = new Vector3(width, noiseDepth, height);
        terrain.terrainData.SetHeights(0, 0, GenerateHeights());
        return terrain.terrainData;
    }

    float[,] GenerateHeights()
    {
        float[,] heights = new float[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                heights[x, y] = CalculateHeight(x, y);
            }
        }

        return heights;
    }

    float CalculateHeight(int x, int y)
    {
        float xCoord = (float)x / width * noiseScale + noisePosX;
        float yCoord = (float)y / width * noiseScale + noisePosY;

        return Mathf.PerlinNoise(xCoord, yCoord);
    }
}
