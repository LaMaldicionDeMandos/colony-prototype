using UnityEngine;
using TMPro;
using Faker;

public class Seed : MonoBehaviour {
    public string seedName;
    private int _seed;
    private TMP_InputField seedInput;
    
    public int seed {
        get => _seed;
    }

    void Start() {
        seedInput = FindSeedInput();
        CalculateSeed();
    }

    void Update() {}

    public void OnNext() {
        CalculateSeed();
    }

    public void GenerateSeed() {
        seedName = seedInput.text;
        _seed = seedName.GetHashCode();
        MapGenerationComponent map = GetComponent<MapGenerationComponent>();
        map.GenerateMap(_seed);
    }

    private void CalculateSeed() {
        seedName = Faker.Name.First();
        seedInput.text = seedName;
        Debug.Log("Hash Code: " + seedName.GetHashCode());
    }

    private TMP_InputField FindSeedInput() {
        Transform inputTransform = transform.Find("Input");
        return inputTransform.GetComponent<TMP_InputField>();
    }
}
