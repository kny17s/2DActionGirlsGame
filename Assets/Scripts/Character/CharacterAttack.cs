using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

public class CharacterAttack : MonoBehaviour
{
	public bool Skill => _skill;

	const float _chargeSp = 4;

	const float _addSp = 40;

	[SerializeField]
	Slider _atkSlider;

	[SerializeField]
	Slider _skillSlider;

	[SerializeField]
	bool _skill = false;

	[SerializeField]
	[Header("キャラクターID")]
	int _id;

	float _currentTime;

	float _currentSp;

	Character _character;

    private async void Start()
	{
		_character = this.gameObject.GetComponent<Character>();

		await UniTask.Delay(TimeSpan.FromSeconds(0.1f));
		_atkSlider.maxValue = CharacterSaveData.I.Agi[_id];
		_atkSlider.value = _atkSlider.minValue;

		_skillSlider.maxValue = CharacterSaveData.I.Sp[_id];
		_skillSlider.value = _skillSlider.minValue;

		this.UpdateAsObservable()
			.Subscribe(_ => Attack(_character.Death))
			.AddTo(this);
	}

	public void UseAttackSkill()
	{
		_currentSp = _skillSlider.minValue;
		_skillSlider.value = _currentSp;

		_skill = false;

		var num = UnityEngine.Random.Range(0, AttakTarget.I.Enemy.Count);
		var damage = (CharacterSaveData.I.Atk[_id] * 2) - EnemySaveData.I.EnemyDef[num];

		if (damage <= 0)
		{
			Debug.Log($"{CharacterDataController.I.SavePath[_id]}の攻撃が効かなかった");
		}

		else
		{
			var i = UnityEngine.Random.Range(0, 5);//_idを使う

			//Animator anim = AttakTarget.I._CharacterImage[j].GetComponent<Animator>();
			//anim.SetTrigger("Attack");

			var damagetarget = AttakTarget.I.Enemy[num].GetComponent<IDamagable>();

			if (damagetarget != null)
			{
				AttakTarget.I.Enemy[num].GetComponent<IDamagable>().AddDamage(damage);
			}
		}
	}

	public void UseRecoverySkill(float recovery)
    {
		_currentSp = _skillSlider.minValue;
		_skillSlider.value = _currentSp;

		_skill = false;

		for (int i = 0; i < 5; i++)
        {
			var recoverytarget = AttakTarget.I.Character[i].GetComponent<IRecovery>();

			if (recoverytarget != null)
			{
				AttakTarget.I.Character[i].GetComponent<IRecovery>().AddRecovery(recovery, i);
			}
		}
    }

	public async void Attack(bool death)
    {
		if (!death)
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
					var i = UnityEngine.Random.Range(0, 5);
					Animator anim = AttakTarget.I._CharacterImage[i].GetComponent<Animator>();
					anim.SetTrigger("Attack");
					await UniTask.Delay(TimeSpan.FromSeconds(1f));

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


			if (_skillSlider.value == _skillSlider.maxValue)
			{
				//Debug.Log("スキルが使用可能です");
				_skill = true;
			}
			else
			{
				_currentSp += (Time.deltaTime * _chargeSp);
			}

			_skillSlider.value = _currentSp;
		}	
	}
}
