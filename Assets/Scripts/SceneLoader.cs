using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader I = null;

    public void Awake() => I = this;
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
