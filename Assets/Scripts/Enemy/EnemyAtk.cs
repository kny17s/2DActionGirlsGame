using Cysharp.Threading.Tasks;
using Ono.MVP.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAtk : MonoBehaviour
{
    [SerializeField]
    Slider _atkSlider;

    float _currentTime;

    [SerializeField]
    Image _characterImage;

    [SerializeField]
    Sprite[] _sprites;
    private async void Start()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(0.1f));
        _atkSlider.maxValue = SaveEnemyCharacterData.I.EnemyAgi[0];
        _atkSlider.value = _atkSlider.minValue;
    }

    void Update()
    {
        if (_currentTime >= _atkSlider.maxValue)
        {
            Debug.Log("çUåÇ");

            _currentTime = _atkSlider.minValue;
            var num = UnityEngine.Random.Range(0, 3);
            var damage = SaveEnemyCharacterData.I.EnemyAtk[0] - SaveCharacterData.I.Def[num];
            Attack();
            CharacterHpModel.I.Damage(damage, num);
        }
        else
        {
            _currentTime += Time.deltaTime;
        }

        _atkSlider.value = _currentTime;

    }

    public async void Attack()
    {
        _characterImage.sprite = _sprites[1];
        await UniTask.Delay(TimeSpan.FromSeconds(1.0f));
        _characterImage.sprite = _sprites[0];
    }
}
