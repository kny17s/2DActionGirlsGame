using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using DG.Tweening;

namespace Ono.MVP.View
{
    public class CharacterHpView : MonoBehaviour
    {
        [SerializeField]
        [Header("キャラクターの体力ゲージ")]
        Slider[] _hpSlider;

        public void Start()
        {
            for(int i = 0; i < _hpSlider.Length; i++)
            {
                _hpSlider[i].maxValue = SaveCharacterData.I.Hp[i];
                _hpSlider[i].value = _hpSlider[i].maxValue;
            }
        }

        public void SetValueCharacter0(float value)
        {
            // アニメーションしながらSliderを動かす
            DOTween.To(() => _hpSlider[0].value,
                n => _hpSlider[0].value = n,
                value,
                duration: 1.0f);

            Debug.Log($"シャルロッテの現在のHP{value}");

            if (value <= 0)
            {
                Debug.Log("シャルロッテのHPが0になりました");
            }
        }

        public void SetValueCharacter1(float value)
        {
            // アニメーションしながらSliderを動かす
            DOTween.To(() => _hpSlider[1].value,
                n => _hpSlider[1].value = n,
                value,
                duration: 1.0f);

            Debug.Log($"リコの現在のHP{value}");

            if (value <= 0)
            {
                Debug.Log("リコのHPが0になりました");
            }
        }

        public void SetValueCharacter2(float value)
        {
            // アニメーションしながらSliderを動かす
            DOTween.To(() => _hpSlider[2].value,
                n => _hpSlider[2].value = n,
                value,
                duration: 1.0f);

            Debug.Log($"しおりの現在のHP{value}");

            if (value <= 0)
            {
                Debug.Log("しおりのHPが0になりました");
            }
        }

        public void SetValueCharacter3(float value)
        {
            // アニメーションしながらSliderを動かす
            DOTween.To(() => _hpSlider[2].value,
                n => _hpSlider[2].value = n,
                value,
                duration: 1.0f);

            Debug.Log($"しおりの現在のHP{value}");

            if (value <= 0)
            {
                Debug.Log("しおりのHPが0になりました");
            }
        }

        public void SetValueCharacter4(float value)
        {
            // アニメーションしながらSliderを動かす
            DOTween.To(() => _hpSlider[2].value,
                n => _hpSlider[2].value = n,
                value,
                duration: 1.0f);

            Debug.Log($"しおりの現在のHP{value}");

            if (value <= 0)
            {
                Debug.Log("しおりのHPが0になりました");
            }
        }

    }
}
