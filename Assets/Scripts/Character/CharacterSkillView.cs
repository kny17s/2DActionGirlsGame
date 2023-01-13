using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSkillView : MonoBehaviour
{
    public static CharacterSkillView I = null;

    [SerializeField]
    [Header("キャラクターのスキルゲージ")]
    Slider[] _skillSlider;

    void Start()
    {
        I = this;

        for (int i = 0; i < _skillSlider.Length; i++)
        {
            _skillSlider[i].maxValue = SaveCharacterData.I.Mp[i];
        }
    }

    public void SetValueCharacter0(float value)
    {
        // アニメーションしながらSliderを動かす
        DOTween.To(() => _skillSlider[0].value,
            n => _skillSlider[0].value = n,
            value,
            duration: 1.0f);

        Debug.Log($"シャルロッテの現在のMP{value}");

        if (value <= 0)
        {
            Debug.Log("シャルロッテのMPが0になりました");
        }
    }

    public void SetValueCharacter1(float value)
    {
        // アニメーションしながらSliderを動かす
        DOTween.To(() => _skillSlider[1].value,
            n => _skillSlider[1].value = n,
            value,
            duration: 1.0f);

        Debug.Log($"リコの現在のMP{value}");

        if (value <= 0)
        {
            Debug.Log("リコのMPが0になりました");
        }
    }

    public void SetValueCharacter2(float value)
    {
        // アニメーションしながらSliderを動かす
        DOTween.To(() => _skillSlider[2].value,
            n => _skillSlider[2].value = n,
            value,
            duration: 1.0f);

        Debug.Log($"しおりの現在のMP{value}");

        if (value <= 0)
        {
            Debug.Log("しおりのMPが0になりました");
        }
    }

}