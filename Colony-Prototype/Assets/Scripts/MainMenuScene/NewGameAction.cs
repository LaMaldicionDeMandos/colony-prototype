using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameAction : MonoBehaviour
{

    private readonly static string NEW_GAME_SCENE = "NewGameScene";

    void Start() {}

    void Update() {}

    public void OnPlay() {
        SceneManager.LoadScene(NEW_GAME_SCENE);
    }
}
