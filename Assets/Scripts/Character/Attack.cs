using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
	//�_���[�W��^����G���A�^�b�`����
	[SerializeField]
	[Header("�_���[�W��^����G�i�U���Ώہj")]
	List<GameObject> _attakTarget = new();

	[SerializeField]
	Slider _atkSlider;

	float _currentTime;

	[SerializeField]
	[Header("�L�����N�^�[ID")]
	int _id;

	bool _atkPhase;

	private async void Start()
	{
		await UniTask.Delay(TimeSpan.FromSeconds(0.1f));
		_atkSlider.maxValue = CharacterSaveData.I.Agi[_id];
		_atkSlider.value = _atkSlider.minValue;
		_atkPhase = true;
	}
	async void Update()
	{
		await UniTask.WaitUntil(() => _atkPhase);

		if (_currentTime >= _atkSlider.maxValue)
		{
			Debug.Log($"{CharacterDataController.I.SavePath[_id]}���U���I");
			_currentTime = _atkSlider.minValue;
			var damage = CharacterSaveData.I.Atk[_id] - EnemySaveData.I.EnemyDef[0];

			if (damage <= 0)
			{
				Debug.Log($"{CharacterDataController.I.SavePath[_id]}�̍U���������Ȃ�����");
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
