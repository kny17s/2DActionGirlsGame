using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarrieEnemy : MonoBehaviour, IDamagable
{
	public bool Death => _death;

	[SerializeField]
	bool _barrieIsEnable = true;

	[SerializeField]
	[Header("キャラクターのHpSlider")]
	Slider _hpSlider;

	/// <summary>現在のHP</summary>
	float _currentHp;

	float _currentDamage;

	[SerializeField]
	bool _death = false;

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
            Debug.Log("バリアを張っている ダメージを与えられない");
			_currentDamage += damage;
			if(_currentDamage >= 50)
            {
				Debug.Log("バリアが壊れた　ダメージを与えられる");
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
			_death = true;
			Debug.Log("BarrieEnemyを倒した");
        }
    }
}