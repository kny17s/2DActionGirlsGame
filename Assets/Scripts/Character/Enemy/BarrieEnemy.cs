using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarrieEnemy : MonoBehaviour, IDamagable
{
	
	[SerializeField]
	bool _barrieIsEnable = true;

	[SerializeField]
	[Header("�L�����N�^�[��HpSlider")]
	Slider _hpSlider;

	/// <summary>���݂�HP</summary>
	float _currentHp;

	float _currentDamage;
	async void Start()
	{
		await UniTask.Delay(TimeSpan.FromSeconds(0.1f));

		_hpSlider.maxValue = EnemySaveData.I.EnemyHp[0];
		_currentHp = _hpSlider.maxValue;
		_hpSlider.value = _currentHp;
	}

	public void AddDamage(float damage)
    {
		if (_barrieIsEnable)
        {
            Debug.Log("�o���A�𒣂��Ă��� �_���[�W��^�����Ȃ�");
			_currentDamage += damage;
			if(_currentDamage >= 100)
            {
				Debug.Log("�o���A����ꂽ�@�_���[�W��^������");
				_barrieIsEnable = false;
				return;
            }
            return;
        }


		_currentHp -= damage;
		_hpSlider.value = _currentHp;
		CreateDamage.I.EnemyDamageText(damage, 1);
		if (_currentHp <= 0)
        {
            Debug.Log("BarrieEnemy��|����");
        }
    }
}