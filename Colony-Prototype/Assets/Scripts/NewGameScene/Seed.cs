using UnityEngine;
using TMPro;
using Faker;

public class Seed : MonoBehaviour {
    public string seed;
    private TMP_InputField seedInput;
    void Start() {
        seedInput = FindSeedInput();
        CalculateSeed();
    }

    void Update() {}

    public void OnNext() {
        CalculateSeed();
    }

    private void CalculateSeed() {
        seed = Faker.Name.First();
        seedInput.text = seed;
        Debug.Log("Hash Code: " + seed.GetHashCode());
    }

    private TMP_InputField FindSeedInput() {
        Transform inputTransform = transform.Find("Input");
        return inputTransform.GetComponent<TMP_InputField>();
    }
}
