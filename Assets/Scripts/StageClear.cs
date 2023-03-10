using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using Cysharp.Threading;

public class StageClear : MonoBehaviour
{
    [SerializeField]
    float _time = 5.0f;

    [SerializeField]
    [Header("クリア時の報酬")]
    int _reward = 1500;

    void Start()
    {
        this.UpdateAsObservable()
            .Subscribe(_ => CountDown())
            .AddTo(this);

        GameCoinData.Instance.AddGachaCoin(_reward);

    }

    public void CountDown()
    {
        if (_time <= 0)
        {
            Debug.Log("画面遷移");
            SceneLoader.Instance.ChangeScene("HomeScene");
        }
        else
        {
            _time -= Time.deltaTime;
        }
    }
}
