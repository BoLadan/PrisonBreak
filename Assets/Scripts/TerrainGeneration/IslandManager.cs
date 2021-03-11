using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandManager : TerrianManager
{
    public float innerRadius;
    public float outerRadius;
    protected override void UpdateTerrainData(float[,] data)
    {
        Terrain t = Terrain.activeTerrain;
        data = ProceduralUtils.IslandFilter(data, innerRadius, outerRadius);
        t.terrainData.heightmapResolution = size.x;
        t.terrainData.SetHeights(0, 0, data);
    }
}
