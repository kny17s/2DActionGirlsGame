using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using DG.Tweening;
using Cysharp.Threading.Tasks;
using System;

namespace Ono.MVP.View
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField]
        [Header("�L�����N�^�[�̗̑̓Q�[�W")]
        Slider _hpSlider;

        public async void Start()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(0.1));
            _hpSlider.maxValue = SaveCharacterData.I.Hp[3];
        }

        public void SetValue(float value)
        {
            DOTween.To(() => _hpSlider.value,
                n => _hpSlider.value = n,
                value,
                duration: 2.0f);

            Debug.Log($"Boss�̌��݂�HP{value}");

            if (value <= 0)
            {
                Debug.Log("Boss��HP��0�ɂȂ�܂���");
            }
        }
    }
}
