using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterAttack : MonoBehaviour
{
	//ダメージを与える敵をアタッチする
	[SerializeField]
	List<GameObject> _attakTarget = new();

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
		_atkSlider.maxValue = SaveCharacterData.I.Agi[_id];
		_atkSlider.value = _atkSlider.minValue;
		_atkPhase = true;
	}
	async void Update()
	{
		await UniTask.WaitUntil(() => _atkPhase);

		if (_currentTime >= _atkSlider.maxValue)
		{
			Debug.Log($"{SaveController.I.SavePath[_id]}が攻撃！");
			_currentTime = _atkSlider.minValue;
			var damage = SaveCharacterData.I.Atk[_id] - SaveEnemyCharacterData.I.EnemyDef[0];

			if (damage <= 0)
			{
				Debug.Log($"{SaveController.I.SavePath[_id]}の攻撃が効かなかった");
			}

			else
			{
				var num = UnityEngine.Random.Range(0, _attakTarget.Count);

				var damagetarget = _attakTarget[num].GetComponent<IDamagable>();

				if (damagetarget != null)
				{
					_attakTarget[num].GetComponent<IDamagable>().AddDamage(damage);
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
