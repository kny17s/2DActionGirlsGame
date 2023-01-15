using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Ono.MVP.Model
{
    public class EnemyModel : MonoBehaviour
    {
        public static EnemyModel I = null;

        public IReadOnlyReactiveProperty<float> CurrentEnemyHp => _currentEnemyHp;
        private readonly FloatReactiveProperty _currentEnemyHp = new FloatReactiveProperty(20f);

        private async void Start()
        {
            I = this;
            await UniTask.Delay(TimeSpan.FromSeconds(0.1));
            _currentEnemyHp.Value = SaveEnemyCharacterData.I.EnemyHp[0];
        }

        public void Damage(float damage)
        {
            _currentEnemyHp.Value -= damage;
        }
    }
}
