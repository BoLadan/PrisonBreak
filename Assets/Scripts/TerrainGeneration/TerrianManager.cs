using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrianManager : TerrainConfig
{
    protected override void UpdateTerrainData(float[,] data)
    {
        Terrain t = Terrain.activeTerrain;
        t.terrainData.heightmapResolution = size.x;
        t.terrainData.SetHeights(0, 0, data);
        t.drawHeightmap = true;
    }

}
