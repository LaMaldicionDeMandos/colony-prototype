using System;
using UnityEngine;

[System.Serializable]
public class ElementSpawnSpec {
    public GameObject Element;

     [SerializeField]
    public ItemSpawnCondition[] SpawnConditions;
}
