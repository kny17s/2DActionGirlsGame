using Cysharp.Threading.Tasks;
using Ono.MVP.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySkill : MonoBehaviour
{
    [SerializeField]
    Slider _skillSlider;

    float _currentTime;

    [SerializeField]
    [Header("�G�̃X�L���g�p�\���x�i�e�X�g�p�j")]
    float _skillSpeed = 10;

    private async void Start()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(0.1f));
        _skillSlider.maxValue = _skillSpeed;
        _skillSlider.value = _skillSlider.minValue;
    }

    void Update()
    {
        if (_currentTime >= _skillSlider.maxValue)
        {
            /*Debug.Log("�X�L�����g����");
            _currentTime = _skillSlider.minValue;
            var num = UnityEngine.Random.Range(0, 3);
            var damage = SaveCharacterData.I.Atk[3] - SaveCharacterData.I.Def[num];
            CharacterHpModel.I.Damage(damage, num);*/
        }
        else
        {
            _currentTime += Time.deltaTime;
        }

        _skillSlider.value = _currentTime;
    }
}
