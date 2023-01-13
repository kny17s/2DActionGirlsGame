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
        [Header("�L�����N�^�[�̗̑̓Q�[�W")]
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
            // �A�j���[�V�������Ȃ���Slider�𓮂���
            DOTween.To(() => _hpSlider[0].value,
                n => _hpSlider[0].value = n,
                value,
                duration: 1.0f);

            Debug.Log($"�V�������b�e�̌��݂�HP{value}");

            if (value <= 0)
            {
                Debug.Log("�V�������b�e��HP��0�ɂȂ�܂���");
            }
        }

        public void SetValueCharacter1(float value)
        {
            // �A�j���[�V�������Ȃ���Slider�𓮂���
            DOTween.To(() => _hpSlider[1].value,
                n => _hpSlider[1].value = n,
                value,
                duration: 1.0f);

            Debug.Log($"���R�̌��݂�HP{value}");

            if (value <= 0)
            {
                Debug.Log("���R��HP��0�ɂȂ�܂���");
            }
        }

        public void SetValueCharacter2(float value)
        {
            // �A�j���[�V�������Ȃ���Slider�𓮂���
            DOTween.To(() => _hpSlider[2].value,
                n => _hpSlider[2].value = n,
                value,
                duration: 1.0f);

            Debug.Log($"������̌��݂�HP{value}");

            if (value <= 0)
            {
                Debug.Log("�������HP��0�ɂȂ�܂���");
            }
        }

        public void SetValueCharacter3(float value)
        {
            // �A�j���[�V�������Ȃ���Slider�𓮂���
            DOTween.To(() => _hpSlider[2].value,
                n => _hpSlider[2].value = n,
                value,
                duration: 1.0f);

            Debug.Log($"������̌��݂�HP{value}");

            if (value <= 0)
            {
                Debug.Log("�������HP��0�ɂȂ�܂���");
            }
        }

        public void SetValueCharacter4(float value)
        {
            // �A�j���[�V�������Ȃ���Slider�𓮂���
            DOTween.To(() => _hpSlider[2].value,
                n => _hpSlider[2].value = n,
                value,
                duration: 1.0f);

            Debug.Log($"������̌��݂�HP{value}");

            if (value <= 0)
            {
                Debug.Log("�������HP��0�ɂȂ�܂���");
            }
        }

    }
}
