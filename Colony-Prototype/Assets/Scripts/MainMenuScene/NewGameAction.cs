using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameAction : MonoBehaviour
{

    private readonly static string MAIN_SCENE = "MainScene";

    void Start() {}

    void Update() {}

    public void OnPlay() {
        SceneManager.LoadScene(MAIN_SCENE);
    }
}
