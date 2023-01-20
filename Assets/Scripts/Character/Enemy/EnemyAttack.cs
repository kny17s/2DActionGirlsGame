using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAttack : MonoBehaviour
{
	[SerializeField]
	Slider _atkSlider;

	float _currentTime;

	[SerializeField]
	[Header("キャラクターID")]
	int _id;

	bool _atkPhase;

	private async void Start()
	{
		await UniTask.Delay(TimeSpan.FromSeconds(0.1f));
		_atkSlider.maxValue = EnemySaveData.I.EnemyAgi[_id];
		_atkSlider.value = _atkSlider.minValue;
		_atkPhase = true;
	}
	async void Update()
	{
		await UniTask.WaitUntil(() => _atkPhase);

		if (_currentTime >= _atkSlider.maxValue)
		{
			Debug.Log($"{EnemyDataController.I.EnemySavePath[_id]}が攻撃！");
			_currentTime = _atkSlider.minValue;
			var damage = EnemySaveData.I.EnemyAtk[_id] - CharacterSaveData.I.Def[0];

			if (damage <= 0)
			{
				Debug.Log($"{EnemyDataController.I.EnemySavePath[_id]}の攻撃が効かなかった");
			}

			else
			{
				var num = UnityEngine.Random.Range(0, AttakTarget.I.Character.Count);

				var damagetarget = AttakTarget.I.Character[num].GetComponent<IDamagable>();
				if (damagetarget != null)
				{
					AttakTarget.I.Character[num].GetComponent<IDamagable>().AddDamage(damage);
				}
			}
		}
		else
		{
			_currentTime += Time.deltaTime;
		}

		_atkSlider.value = _currentTime;
	}
}
