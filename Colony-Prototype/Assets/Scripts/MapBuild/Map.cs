using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class Map {
    public static Map BuildBySeed(int seed, MapGenerationConfig config) {
        List<Tuple<float, TerrainSpec>> terrainConfig = GenerateTerrainDictionary(config.terrains);
        TerrainSpec[,] terrainSpecs = GenerateTerrains(seed, terrainConfig, config);
        List<Tuple<string, Vector2>> items = GenerateSpawnItems(seed, config.width, config.heigth, config.itemSpecs, terrainSpecs);
        return new Map(config.width, config.heigth, terrainSpecs, items);
    }

    private static List<Tuple<float, TerrainSpec>> GenerateTerrainDictionary(TerrainSpec[] terrains) {
        List<Tuple<float, TerrainSpec>> specs = new List<Tuple<float, TerrainSpec>>();
        float sum = SumTerrainweights(terrains);
        float currentLimit = 0.0f;
        foreach( TerrainSpec terrain in terrains) {
            currentLimit+= terrain.weight/sum;
            specs.Add(new Tuple<float, TerrainSpec>(currentLimit, terrain)); 
        }
        return specs;
    }

    private static float SumTerrainweights(TerrainSpec[] terrains) {
        float sum = 0.0f;
        foreach(TerrainSpec terrain in terrains) {
            sum+= terrain.weight;
        }
        return sum;
    }

    private static TerrainSpec[,] GenerateTerrains(int seed, List<Tuple<float, TerrainSpec>> terrainsConfig, MapGenerationConfig config) {
        float[,] noiseMap = GenerateNoiseMap(config.width, config.heigth, config.noise, seed);
        TerrainSpec[,] terrains = new TerrainSpec[config.width, config.heigth];
        for(int i = 0; i < config.width; i++) {
            for(int j = 0; j < config.heigth; j++) {
                int terrainIndex = GetTerrainIndex(Mathf.Clamp(noiseMap[i, j], 0.0f, 1.0f), terrainsConfig);
                terrains[i, j] = terrainsConfig[terrainIndex].Item2;
            }
        }
        return terrains;
    }

    private static int GetTerrainIndex(float noise, List<Tuple<float, TerrainSpec>> ranges) {
        for(int i = 0; i < ranges.Count; i++) {
            if (noise <= ranges[i].Item1) return i;
        }
        return 0;
    }

    private static float[,] GenerateNoiseMap(int mapWidth, int mapHeigth, float elevationScale, int seed) {
        float[,] noiseMap = new float[mapWidth, mapHeigth];
        System.Random rand = new System.Random(seed);

        float offsetX = rand.Next(-100000, 100000);
        float offsetY = rand.Next(-100000, 100000);

        for (int i = 0; i < mapWidth; i++) {
            for (int j = 0; j < mapHeigth; j++) {
                float x = (float)i / mapWidth * elevationScale + offsetX;
                float y = (float)j / mapHeigth * elevationScale + offsetY;
                noiseMap[i, j] = Mathf.PerlinNoise(x, y);
            }
        }
        return noiseMap;
    }

    private static List<Tuple<string, Vector2>> GenerateSpawnItems(int seed, int width, int heigth, MapItemSpec[] itemSpecs, TerrainSpec[,] terrains) {
        System.Random rand = new System.Random(seed);
        List<Tuple<string, Vector2>> items = new List<Tuple<string, Vector2>>();
        for (int i = 0; i < width; i++) {
            for(int j = 0; j < heigth; j++) {
                string terrainName = terrains[i, j].terrainName;
                foreach( MapItemSpec itemSpec in itemSpecs) {
                    if (shouldAddItem(rand, terrainName, itemSpec.spawnConditions)) items.Add(new Tuple<string, Vector2>(itemSpec.itemName, new Vector2(i, j)));
                }
            }
        }
        return items;
    }

    private static bool shouldAddItem(System.Random rand, string terrainName, ItemSpawnCondition[] conditions) {

        if (conditions.Any(conditions => conditions.terrainName == terrainName)) {
            double r = rand.NextDouble();
            ItemSpawnCondition condition = conditions.Single(conditions => conditions.terrainName == terrainName);
            return r < condition.percent;
        }
        return false;
    }

    public int width;
    public int heigth;

    [SerializeField]
    public readonly TerrainSpec[,] terrainMatrix;
    public readonly List<Tuple<string, Vector2>> items;

    public Map(int width, int heigth, TerrainSpec[,] terrainMatrix, List<Tuple<string, Vector2>> items) {
        this.width = width;
        this.heigth = heigth;
        this.terrainMatrix = terrainMatrix;
        this.items = items;
    }
}
