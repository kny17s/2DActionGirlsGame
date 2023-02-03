using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    private float step_time;    // 経過時間カウント用

    void Awake()
    {
        step_time = 0.0f;       // 経過時間初期化
    }

    void Update()
    {
        // 経過時間をカウント
        step_time += Time.deltaTime;

        // 3秒後に画面を楽曲選択へ移動
        if (step_time >= 3.0f)
        {
            SceneLoader.I.LoadScene("BattleScene");
        }
    }
}
