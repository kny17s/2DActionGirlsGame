using System.Collections;
using UniRx;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;

namespace Ono.MVP.Model
{
    public class CharacterHpModel : MonoBehaviour
    {
        public static CharacterHpModel I = null;

        public IReadOnlyReactiveProperty<float> CurrentHp_0 => _currentHp_0;
        private readonly FloatReactiveProperty _currentHp_0 = new FloatReactiveProperty(10f);

        public IReadOnlyReactiveProperty<float> CurrentHp_1 => _currentHp_1;
        private readonly FloatReactiveProperty _currentHp_1 = new FloatReactiveProperty(10f);

        public IReadOnlyReactiveProperty<float> CurrentHp_2 => _currentHp_2;
        private readonly FloatReactiveProperty _currentHp_2 = new FloatReactiveProperty(10f);

        public IReadOnlyReactiveProperty<float> CurrentHp_3 => _currentHp_3;
        private readonly FloatReactiveProperty _currentHp_3 = new FloatReactiveProperty(10f);

        public IReadOnlyReactiveProperty<float> CurrentHp_4 => _currentHp_4;
        private readonly FloatReactiveProperty _currentHp_4 = new FloatReactiveProperty(10f);

        private async void Start()
        {
            I = this;
            await UniTask.Delay(TimeSpan.FromSeconds(0.2f));
            SettingHp();
        }

        public void SettingHp()
        {
            _currentHp_0.Value = SaveCharacterData.I.Hp[0];
            _currentHp_1.Value = SaveCharacterData.I.Hp[1];
            _currentHp_2.Value = SaveCharacterData.I.Hp[2];
            _currentHp_3.Value = SaveCharacterData.I.Hp[3];
            _currentHp_4.Value = SaveCharacterData.I.Hp[4];
        }

        public void Damage(float damage, int id)
        {
            switch (id)
            {
                case 0:
                    _currentHp_0.Value -= damage;
                    break;
                case 1:
                    _currentHp_1.Value -= damage;
                    break;
                case 2:
                    _currentHp_2.Value -= damage;
                    break;
                case 3:
                    _currentHp_3.Value -= damage;
                    break;
                case 4:
                    _currentHp_4.Value -= damage;
                    break;
            }

        }

        public void Recovery(float recovery, int id)
        {
            switch (id)
            {
                case 0:
                    if (_currentHp_0.Value < SaveCharacterData.I.Hp[id])
                    {
                        _currentHp_0.Value += recovery;
                    }
                    break;
                case 1:
                    if (_currentHp_1.Value < SaveCharacterData.I.Hp[id])
                    {
                        _currentHp_1.Value += recovery;
                    }
                    break;
                case 2:
                    if (_currentHp_2.Value < SaveCharacterData.I.Hp[id])
                    {
                        _currentHp_2.Value += recovery;
                    }
                    break;
                case 3:
                    if (_currentHp_3.Value < SaveCharacterData.I.Hp[id])
                    {
                        _currentHp_3.Value += recovery;
                    }
                    break;
                case 4:
                    if (_currentHp_4.Value < SaveCharacterData.I.Hp[id])
                    {
                        _currentHp_4.Value += recovery;
                    }
                    break;
            }

        }
    }
}
