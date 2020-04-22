using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static SceneChanger instance;

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(this);
        }
    }

    public void ChangeScene(string scene) {
        SceneManager.LoadScene(scene);
    }

    public static void ChangeSceneStatic(string scene) {
        instance.ChangeScene(scene);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
