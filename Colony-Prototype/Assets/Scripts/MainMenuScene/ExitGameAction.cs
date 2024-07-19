using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGameAction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {}

    // Update is called once per frame
    void Update() {}

    public void QuitGame() {
        // Si estás en el editor de Unity, esto no cerrará el editor
        // En cambio, puedes usar Debug.Log para comprobar que el método se ha llamado
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
