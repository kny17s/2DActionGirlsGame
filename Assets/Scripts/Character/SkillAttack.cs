using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Cysharp.Threading.Tasks;
using System;

public class SkillAttack : MonoBehaviour
{
    public static SkillAttack I = null; 
    [SerializeField]
    Slider _skillSlider;

    float _currentSp;

    [SerializeField]
    [Header("キャラクターID")]
    int _id;

    bool _atkPhase;

    bool _skill = false;
    private async void Start()
    {
        I = this;
        await UniTask.Delay(TimeSpan.FromSeconds(0.1f));
        _skillSlider.maxValue = CharacterSaveData.I.Sp[_id];
        _skillSlider.value = 0;
        _atkPhase = true;
    }

    async void Update()
    {
        await UniTask.WaitUntil(() => _atkPhase);

        if (_currentSp >= _skillSlider.maxValue && _skill == false)
        {
            Debug.Log("スキルが使えるよ");
            _skill = true;
        }
        else
        {
            _currentSp += (Time.deltaTime / 0.5f);
        }

        _skillSlider.value = _currentSp;
    }

    public void UseSkill()
    {
        _skillSlider.value = _skillSlider.minValue;
    }
}
