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

	[SerializeField]
	Slider _atkSlider;

	[SerializeField]
	Slider _skillSlider;

	[SerializeField]
	bool _skill = false;

	float _currentTime;

	float _currentSp;

	Character _character;

    private async void Start()
	{
		_character = this.gameObject.GetComponent<Character>();

		await UniTask.Delay(TimeSpan.FromSeconds(0.1f));
		_atkSlider.maxValue = CharacterSaveData.Instance.Agi[_character.Id];
		_atkSlider.value = _atkSlider.minValue;

		_skillSlider.maxValue = CharacterSaveData.Instance.Mp[_character.Id];
		_skillSlider.value = _skillSlider.minValue;

		this.UpdateAsObservable()
			.Subscribe(_ => Attack(_character.Death))
			.AddTo(this);
	}

	public async void UseSkill()
    {
		if (_skill == true && !_character.Death)
		{
			Debug.Log("スキルを使用しました。");

			BattleManager.Instance.SkillEffect(_character.Id);
			await UniTask.Delay(TimeSpan.FromSeconds(2.5f));

			switch (_character.Id)
			{
				case 0:
					UseAttackSkill();
					break;
				case 1:
					UseRecoverySkill(CharacterSaveData.Instance.Atk[_character.Id]);
					break;
				case 2:
					UseAttackSkill();
					break;
				case 3:
					UseRecoverySkill(CharacterSaveData.Instance.Atk[_character.Id]);
					break;
				case 4:
					UseAttackSkill();
					break;
				case 5:
					UseRecoverySkill(CharacterSaveData.Instance.Atk[_character.Id]);
					break;
				case 6:
					UseAttackSkill();
					break;
				case 7:
					UseRecoverySkill(CharacterSaveData.Instance.Atk[_character.Id]);
					break;
				case 8:
					UseAttackSkill();
					break;
				case 9:
					UseRecoverySkill(CharacterSaveData.Instance.Atk[_character.Id]);
					break;
			}

		}
		else if (_skill == false)
		{
			Debug.Log("ゲージがたまっていません");
		}
		else if (_character.Death)
		{
			Debug.Log("死んでいます");
		}
	}

	private void UseAttackSkill()
	{
		_currentSp = _skillSlider.minValue;
		_skillSlider.value = _currentSp;

		_skill = false;

		var num = UnityEngine.Random.Range(0, BattleManager.Instance.EnemyObjects.Count);
		var damage = (CharacterSaveData.Instance.Atk[_character.Id] * 2) - EnemySaveData.Instance.EnemyDef[num];

		if (damage <= 0)
		{
			Debug.Log($"{CharacterDataController.Instance.SavePath[_character.Id]}の攻撃が効かなかった");
		}

		else
		{
			var i = UnityEngine.Random.Range(0, 5);

			//Animator anim = AttakTarget.I._CharacterImage[j].GetComponent<Animator>();
			//anim.SetTrigger("Attack");

			var damagetarget = BattleManager.Instance.EnemyObjects[num].GetComponent<IDamagable>();

			if (damagetarget != null)
			{
				BattleManager.Instance.EnemyObjects[num].GetComponent<IDamagable>().AddDamage(damage);
			}
		}
	}

	private void UseRecoverySkill(float recovery)
    {
		_currentSp = _skillSlider.minValue;
		_skillSlider.value = _currentSp;

		_skill = false;

		for (int i = 0; i < 5; i++)
        {
			var recoverytarget = BattleManager.Instance.CharacterDatas[i].GetComponent<IRecovery>();

			if (recoverytarget != null)
			{
				BattleManager.Instance.CharacterDatas[i].GetComponent<IRecovery>().AddRecovery(recovery, i);
			}
		}
    }

	private async void Attack(bool death)
    {
		if (!death)
		{
			if (_currentTime >= _atkSlider.maxValue)
			{
				Debug.Log($"{CharacterDataController.Instance.SavePath[_character.Id]}が攻撃！");

				_currentTime = _atkSlider.minValue;
				var num = UnityEngine.Random.Range(0, BattleManager.Instance.EnemyObjects.Count);
				var damage = CharacterSaveData.Instance.Atk[_character.Id] - EnemySaveData.Instance.EnemyDef[num];

				if (damage <= 0)
				{
					Debug.Log($"{CharacterDataController.Instance.SavePath[_character.Id]}の攻撃が効かなかった");
				}

				else
				{
					var i = UnityEngine.Random.Range(0, 5);
					Animator anim = BattleManager.Instance._CharacterImage[i].GetComponent<Animator>();
					anim.SetTrigger("Attack");
					await UniTask.Delay(TimeSpan.FromSeconds(1f));

					var damagetarget = BattleManager.Instance.EnemyObjects[num].GetComponent<IDamagable>();

					if (damagetarget != null)
					{
						BattleManager.Instance.EnemyObjects[num].GetComponent<IDamagable>().AddDamage(damage);
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
				_skill = true;
			}
			else
			{
				_currentSp += Time.deltaTime;
			}

			_skillSlider.value = _currentSp;
		}	
	}
}
