using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBoss : MonoBehaviour,IDamagable
{
    [SerializeField]
    int _RestorableCount = 1;

    [SerializeField]
    [Header("キャラクターのHpSlider")]
    Slider _hpSlider;

    /// <summary>現在のHP</summary>
    float _currentHp;

    async void Start()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(0.1f));

        _hpSlider.maxValue = SaveEnemyCharacterData.I.EnemyHp[0];
        _currentHp = _hpSlider.maxValue;
        _hpSlider.value = _currentHp;
    }

    public void AddDamage(float damage)
    {
        _currentHp -= damage;
        Debug.Log("add: " + damage + "hp: " + _currentHp);
        CreateDamage.I.EnemyDamageText(damage, 2);
        if (_currentHp < 0 && _RestorableCount > 0)
        {
            _RestorableCount -= 1;
            _currentHp = _hpSlider.maxValue;
        }

        if (_currentHp < 0 && _RestorableCount <= 0)
        {
            Debug.Log("Bossを倒した");
        }
    }
}
