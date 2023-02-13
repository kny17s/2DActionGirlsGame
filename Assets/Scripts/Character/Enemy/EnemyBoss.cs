using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBoss : MonoBehaviour,IDamagable
{
    public bool Death => _death;

    [SerializeField]
    int _RestorableCount = 1;

    [SerializeField]
    [Header("キャラクターのHpSlider")]
    Slider _hpSlider;

    /// <summary>現在のHP</summary>
    float _currentHp;

    [SerializeField]
    bool _death = false;

    async void Start()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(0.1f));

        _hpSlider.maxValue = EnemySaveData.Instance.EnemyHp[0];
        _currentHp = _hpSlider.maxValue;
        _hpSlider.value = _currentHp;
    }

    public void AddDamage(float damage)
    {
        _currentHp -= damage;
        _hpSlider.value = _currentHp;
        CreateDamageText.Instance.EnemyDamageText(damage, 2);

        if (_currentHp < 0 && _RestorableCount > 0)
        {
            _RestorableCount -= 1;
            _currentHp = _hpSlider.maxValue;
        }

        if (_currentHp < 0 && _RestorableCount <= 0)
        {
            _death = true;
            Debug.Log("Bossを倒した");
            //できたらアニメーション入れたい
            gameObject.SetActive(false);
            TargetManager.Instance.EnemyDeathCheck();
        }
    }
}
