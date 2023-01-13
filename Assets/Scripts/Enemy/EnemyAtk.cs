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

    private async void Start()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(0.1f));
        _atkSlider.maxValue = SaveCharacterData.I.Agi[3];
        _atkSlider.value = _atkSlider.minValue;
    }

    void Update()
    {
        if (_currentTime >= _atkSlider.maxValue)
        {
            Debug.Log("UŒ‚");

            _currentTime = _atkSlider.minValue;
            var num = UnityEngine.Random.Range(0, 3);
            var damage = SaveCharacterData.I.Atk[3] - SaveCharacterData.I.Def[num];
            CharacterHpModel.I.Damage(damage, num);
        }
        else
        {
            _currentTime += Time.deltaTime;
        }

        _atkSlider.value = _currentTime;
    }
}
