using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MapGenerationConfig {
    public int width;
    public int heigth;
    public float noise;

    public TerrainSpec[] terrains;

    public MapItemSpec[] itemSpecs;
}
