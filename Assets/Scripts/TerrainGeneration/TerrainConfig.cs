using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainConfig : MonoBehaviour
{
    public Vector2Int size = new Vector2Int(512, 512);

    public float scale = 5f;

    [Range(0, 1)]
    public float baseAmplitude = 1f;

    [Range(1, 10)]
    public int octaves = 4;

    [Range(1f, 3f)]
    public float lacunarity = 1.8f;

    [Range(0f, 1f)]
    public float persistance = 0.5f;

    public Vector3 offset = Vector3.zero;

    private void Start()
    {
        UpdateTerrainData(GenerateTerrainData());
    }

    private float[,] GenerateTerrainData()
    {
        return ProceduralUtils.GenerateTerrainData(size.x, size.y, scale / 1000f, baseAmplitude, octaves, lacunarity, persistance, offset);
    }

    protected virtual void UpdateTerrainData(float[,] data)
    {

    }

    private void OnValidate()
    {
        UpdateTerrainData(GenerateTerrainData());
    }
}
