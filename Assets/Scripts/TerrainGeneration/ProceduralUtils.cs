using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ProceduralUtils
{
    public static Texture2D GenerateTexture2D(float[,] data)
    {
        int width = data.GetLength(0);
        int height = data.GetLength(1);

        Texture2D texture = new Texture2D(width, height);
        Color[] colors = new Color[width * height];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                int i = x + width * y;
                float value = data[x, y];
                colors[i] = new Color(value, value, value);
            }
        }

        texture.SetPixels(colors);
        texture.Apply();

        return texture;
    }

    public static float[,] IslandFilter(float[,] data, float innerRadius, float outerRadius)
    {
        //Do stuff
        float multiplier;
        int width = data.GetLength(0);
        int heigth = data.GetLength(1);
        Vector2Int center = new Vector2Int(width / 2, heigth / 2);

        for (int y = 0; y < data.GetLength(1); y++)
        {
            for (int x = 0; x < data.GetLength(0); x++)
            {
                Vector2Int point = new Vector2Int(x, y);
                float dist = Vector2.Distance(point, center);

                if (dist < innerRadius)
                {
                    multiplier = 1;
                }
                else if (dist > outerRadius)
                {
                    multiplier = 0;
                }
                else
                {
                    multiplier = Utils.Map(dist, innerRadius, outerRadius, 1, 0);
                }

                data[x, y] *= multiplier;
            }
        }

        return data;
    }

    public static float[,] GenerateTerrainData(int width, int height, float scale, float baseAmplitude,int octaves, float lacunarity, float persistence, Vector3 offset)
    {
        float[,] result = new float[width, height];

        float maxValue = float.MinValue;
        float minValue = float.MaxValue;

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                result[x, y] = 0;
                float frequency = scale;
                float amplitude = baseAmplitude;
                for (int o = 0; o < octaves; o++)
                {
                    frequency *= lacunarity;
                    amplitude *= persistence;
                    result[x, y] += (GetPerlinValue(x + offset.x, y + offset.y, frequency, amplitude) + offset.z/100f);
                    if (result[x, y] > maxValue)
                    {
                        maxValue = result[x, y];
                    }
                    if (result[x, y] < minValue)
                    {
                        minValue = result[x, y];
                    }
                }
            }
        }

        return result;
    }

    public static float GetPerlinValue(float x, float y, float frequency, float amplitude)
    {
        float result = (Mathf.PerlinNoise(x*frequency, y*frequency) * 2f - 1f) * amplitude;


        return result;
    }
}
