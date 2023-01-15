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
        [Header("キャラクターの体力ゲージ")]
        Slider[] _hpSlider;

        public async void Start()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(0.1));
            _hpSlider[0].maxValue = SaveEnemyCharacterData.I.EnemyHp[0];
        }

        public void SetValue(float value)
        {
            DOTween.To(() => _hpSlider[0].value,
                n => _hpSlider[0].value = n,
                value,
                duration: 1.5f);

            Debug.Log($"Bossの現在のHP{value}");

            if (value <= 0)
            {
                Debug.Log("BossのHPが0になりました");
            }
        }
    }
}
