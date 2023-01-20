using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterAttack : MonoBehaviour
{
	[SerializeField]
	Slider _atkSlider;

	float _currentTime;

	[SerializeField]
	Slider _skillSlider;

	float _currentSp;

	bool _skill = false;

	[SerializeField]
	[Header("キャラクターID")]
	int _id;

	private async void Start()
	{
		await UniTask.Delay(TimeSpan.FromSeconds(0.1f));
		_atkSlider.maxValue = CharacterSaveData.I.Agi[_id];
		_atkSlider.value = _atkSlider.minValue;

		_skillSlider.maxValue = CharacterSaveData.I.Sp[_id];
		_skillSlider.value = 0;

	}

	private void Update()
	{
		if (_currentTime >= _atkSlider.maxValue)
		{
			Debug.Log($"{CharacterDataController.I.SavePath[_id]}が攻撃！");

			_currentTime = _atkSlider.minValue;
			var num = UnityEngine.Random.Range(0, AttakTarget.I.Enemy.Count);
			var damage = CharacterSaveData.I.Atk[_id] - EnemySaveData.I.EnemyDef[num];

			if (damage <= 0)
			{
				Debug.Log($"{CharacterDataController.I.SavePath[_id]}の攻撃が効かなかった");
			}

			else
			{
				//animationで攻撃モーションを再生
				var damagetarget = AttakTarget.I.Enemy[num].GetComponent<IDamagable>();

				if (damagetarget != null)
				{
					AttakTarget.I.Enemy[num].GetComponent<IDamagable>().AddDamage(damage);
				}
			}
		}
		else
		{
			_currentTime += Time.deltaTime;
		}

		_atkSlider.value = _currentTime;


		if (_currentSp >= _skillSlider.maxValue && _skill == false)
		{
			Debug.Log("スキルが使用可能です");
			//animation.SetBoolでキャラクターフレームを点滅させる
			_skill = true;
		}
		else
		{
			_currentSp += Time.deltaTime;
		}

		_skillSlider.value = _currentSp;
	}

	public void UseSkill()
	{
		_skillSlider.value = _skillSlider.minValue;
		//animationを止め非表示にする
		_skill = false;
	}
}
