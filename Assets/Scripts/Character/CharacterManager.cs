using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
	/// <summary>���݂�Hp</summary>
	public float[] CurrentHp => _currentHp;

	[SerializeField]
	[Header("�L�����N�^�[��HpSlider")]
	List<Slider> _hpSlider = new();

	/// <summary>���݂�HP</summary>
	[SerializeField]
	float[] _currentHp;

    async void Start()
	{
		await UniTask.Delay(TimeSpan.FromSeconds(0.1f));

		for (int i  = 0; i < _hpSlider.Count; i++)
        {
			_hpSlider[i].maxValue = SaveCharacterData.I.Hp[i];
			_currentHp[i] = _hpSlider[i].maxValue;
			_hpSlider[i].value = _currentHp[i];
		}
	}

	public void AddDamage(float damage, int id)
    {
		// �A�j���[�V�������Ȃ���Slider�𓮂���
		DOTween.To(() => _hpSlider[id].value,
			n => _hpSlider[id].value = n,
			damage,
			duration: 1.0f);

		_currentHp[id] -= damage;
		_hpSlider[id].value = _currentHp[id];
		Debug.Log("slider.value = " + _hpSlider[id].value);

		if (_hpSlider[id].value <= 0)
		{
			Debug.Log($"{SaveController.I.SavePath[id]}��Hp���Ȃ��Ȃ�܂���");
		}
	}
}
