using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour,IDamagable
{
	[SerializeField]
	[Header("キャラクターのHpSlider")]
    Slider _hpSlider;

	/// <summary>現在のHP</summary>
	float _currentHp;

	async void Start()
	{
		await UniTask.Delay(TimeSpan.FromSeconds(0.1f));

		_hpSlider.maxValue = EnemySaveData.I.EnemyHp[0];
		_currentHp = _hpSlider.maxValue;
		_hpSlider.value = _currentHp;
	}

	public void AddDamage(float damage)
	{

		_currentHp -= damage;
		_hpSlider.value = _currentHp;
		CreateDamage.I.EnemyDamageText(damage, 0);
		if (_currentHp <= 0)
		{
			Debug.Log("Enemyを倒した");
		}
	}
}
