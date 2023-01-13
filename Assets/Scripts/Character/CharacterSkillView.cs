using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSkillView : MonoBehaviour
{
    [SerializeField]
    [Header("�L�����N�^�[�̃X�L���Q�[�W")]
    Slider[] _skillSlider;

    public async void Start()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(0.1f));

        for (int i = 0; i < _skillSlider.Length; i++)
        {
            _skillSlider[i].maxValue = SaveCharacterData.I.Mp[i];
            _skillSlider[i].value = _skillSlider[i].maxValue;
        }
    }

    public void SetValueCharacter0(float value)
    {
        // �A�j���[�V�������Ȃ���Slider�𓮂���
        DOTween.To(() => _skillSlider[0].value,
            n => _skillSlider[0].value = n,
            value,
            duration: 1.0f);

        Debug.Log($"�V�������b�e�̌��݂�MP{value}");

        if (value <= 0)
        {
            Debug.Log("�V�������b�e��MP��0�ɂȂ�܂���");
        }
    }

    public void SetValueCharacter1(float value)
    {
        // �A�j���[�V�������Ȃ���Slider�𓮂���
        DOTween.To(() => _skillSlider[1].value,
            n => _skillSlider[1].value = n,
            value,
            duration: 1.0f);

        Debug.Log($"���R�̌��݂�MP{value}");

        if (value <= 0)
        {
            Debug.Log("���R��MP��0�ɂȂ�܂���");
        }
    }

    public void SetValueCharacter2(float value)
    {
        // �A�j���[�V�������Ȃ���Slider�𓮂���
        DOTween.To(() => _skillSlider[2].value,
            n => _skillSlider[2].value = n,
            value,
            duration: 1.0f);

        Debug.Log($"������̌��݂�MP{value}");

        if (value <= 0)
        {
            Debug.Log("�������MP��0�ɂȂ�܂���");
        }
    }

    public void SetValueCharacter3(float value)
    {
        // �A�j���[�V�������Ȃ���Slider�𓮂���
        DOTween.To(() => _skillSlider[3].value,
            n => _skillSlider[3].value = n,
            value,
            duration: 1.0f);

        Debug.Log($"������̌��݂�MP{value}");

        if (value <= 0)
        {
            Debug.Log("�������MP��0�ɂȂ�܂���");
        }
    }

    public void SetValueCharacter4(float value)
    {
        // �A�j���[�V�������Ȃ���Slider�𓮂���
        DOTween.To(() => _skillSlider[4].value,
            n => _skillSlider[4].value = n,
            value,
            duration: 1.0f);

        Debug.Log($"������̌��݂�MP{value}");

        if (value <= 0)
        {
            Debug.Log("�������MP��0�ɂȂ�܂���");
        }
    }

}