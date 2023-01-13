using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class CharacterSkillModel : MonoBehaviour
{
    public static CharacterSkillModel I = null;

    public IReadOnlyReactiveProperty<float> CurrentSp_0 => _currentMp_0;
    private readonly FloatReactiveProperty _currentMp_0 = new FloatReactiveProperty(200f);

    public IReadOnlyReactiveProperty<float> CurrentSp_1 => _currentMp_1;
    private readonly FloatReactiveProperty _currentMp_1 = new FloatReactiveProperty(200f);

    public IReadOnlyReactiveProperty<float> CurrentSp_2 => _currentMp_2;
    private readonly FloatReactiveProperty _currentMp_2 = new FloatReactiveProperty(200f);

    public IReadOnlyReactiveProperty<float> CurrentSp_3 => _currentMp_3;
    private readonly FloatReactiveProperty _currentMp_3 = new FloatReactiveProperty(200f);

    public IReadOnlyReactiveProperty<float> CurrentSp_4 => _currentMp_4;
    private readonly FloatReactiveProperty _currentMp_4 = new FloatReactiveProperty(200f);

    private async void Start()
    {
        I = this;
        await UniTask.Delay(TimeSpan.FromSeconds(0.2f));
        SettingMp();
    }

    public void SettingMp()
    {
        _currentMp_0.Value = SaveCharacterData.I.Mp[0];
        _currentMp_1.Value = SaveCharacterData.I.Mp[1];
        _currentMp_2.Value = SaveCharacterData.I.Mp[2];
        _currentMp_3.Value = SaveCharacterData.I.Mp[3];
        _currentMp_4.Value = SaveCharacterData.I.Mp[4];
    }

    public void UseMP(float usedMp, int num)
    {
        switch (num)
        {
            case 0:
                _currentMp_0.Value -= usedMp;
                break;
            case 1:
                _currentMp_1.Value -= usedMp;
                break;
            case 2:
                _currentMp_2.Value -= usedMp;
                break;
            case 3:
                _currentMp_3.Value -= usedMp;
                break;
            case 4:
                _currentMp_4.Value -= usedMp;
                break;
        }

    }

    public void RecoverySp(float recovery, int num)
    {
        switch (num)
        {
            case 0:
                if (_currentMp_0.Value < SaveCharacterData.I.Mp[num])
                {
                    _currentMp_0.Value += recovery;
                }
                break;
            case 1:
                if (_currentMp_1.Value < SaveCharacterData.I.Mp[num])
                {
                    _currentMp_1.Value += recovery;
                }
                break;
            case 2:
                if (_currentMp_2.Value < SaveCharacterData.I.Mp[num])
                {
                    _currentMp_2.Value += recovery;
                }
                break;
            case 3:
                if (_currentMp_3.Value < SaveCharacterData.I.Mp[num])
                {
                    _currentMp_3.Value += recovery;
                }
                break;
            case 4:
                if (_currentMp_4.Value < SaveCharacterData.I.Mp[num])
                {
                    _currentMp_4.Value += recovery;
                }
                break;
        }

    }
}
