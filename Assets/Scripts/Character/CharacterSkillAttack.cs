using Ono.MVP.Model;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Cysharp.Threading.Tasks;
using System;

public class CharacterSkillAttack : MonoBehaviour
{
    [SerializeField]
    Slider _atkSlider;

    float _currentTime;

    [SerializeField]
    [Header("キャラクターID")]
    int _id;

    [SerializeField]
    Text _damageText;

    bool _atkPhase;

    private async void Start()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(0.1f));
        _atkSlider.maxValue = SaveCharacterData.I.Mp[_id];
        _atkSlider.value = _atkSlider.minValue;
        _atkPhase = true;
    }

    async void Update()
    {
        await UniTask.WaitUntil(() => _atkPhase);

        if (_currentTime >= _atkSlider.maxValue)
        {
            Debug.Log("スキル攻撃ができるよ！");

            _currentTime = _atkSlider.minValue;

        }
        else
        {
            _currentTime += Time.deltaTime;
        }

        _atkSlider.value = _currentTime;
    }
}
