using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour,IDamagable
{

	[SerializeField]
	[Header("�L�����N�^�[��HpSlider")]
	Slider _hpSlider;

	[SerializeField]
	[Header("�L�����N�^�[ID")]
	int _id;

	float _currentHp;

	async void Start()
	{
		await UniTask.Delay(TimeSpan.FromSeconds(0.1f));

		_hpSlider.maxValue = CharacterSaveData.I.Hp[_id];
		_currentHp = _hpSlider.maxValue;
		_hpSlider.value = _currentHp;
	}

	/// <summary>�_���[�W���󂯂����̏���</summary>
	/// <param name="damage">�_���[�W��</param>
	public void AddDamage(float damage)
    {
		_currentHp -= damage;
		_hpSlider.value = _currentHp;
		Debug.Log("Hp: " + _hpSlider.value);
		CreateDamage.I.CharacterDamageText(damage, _id);
		if (_hpSlider.value <= 0)
		{
			Debug.Log($"{CharacterDataController.I.SavePath[_id]}��Hp���Ȃ��Ȃ�܂���");
		}
	}
}
