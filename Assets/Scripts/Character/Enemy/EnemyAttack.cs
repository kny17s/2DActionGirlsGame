using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

public class EnemyAttack : MonoBehaviour
{
	[SerializeField]
	Slider _atkSlider;

	float _currentTime;

	[SerializeField]
	[Header("キャラクターID")]
	int _id;

	bool _atkPhase = false;

	[SerializeField]
	Text _attackTimeText;

	Enemy _enemy;
	EnemyBoss _enemyBoss;
	BarrieEnemy _barrieEnemy;

	private async void Start()
    {
		await UniTask.Delay(TimeSpan.FromSeconds(0.1f));

		_atkSlider.maxValue = EnemySaveData.Instance.EnemyAgi[_id];
		_atkSlider.value = _atkSlider.maxValue;
		_currentTime = _atkSlider.maxValue;

		switch (_id)
        {
			case 0:
				_enemy = gameObject.GetComponent<Enemy>();
				await UniTask.Delay(TimeSpan.FromSeconds(0.1f));

				this.UpdateAsObservable()
					.Subscribe(_ => Attack(_enemy.Death))
					.AddTo(this);

				break;
			case 1:
				_barrieEnemy = gameObject.GetComponent<BarrieEnemy>();
				await UniTask.Delay(TimeSpan.FromSeconds(0.1f));

				this.UpdateAsObservable()
					.Subscribe(_ => Attack(_barrieEnemy.Death))
					.AddTo(this);

				break;
			case 2:
				_enemyBoss = gameObject.GetComponent<EnemyBoss>();
				await UniTask.Delay(TimeSpan.FromSeconds(0.1f));

				this.UpdateAsObservable()
					.Subscribe(_ => Attack(_enemyBoss.Death))
					.AddTo(this);

				break;
		}

		_atkPhase = true;
	}

	public async void Attack(bool death)
    {
		await UniTask.WaitUntil(() => _atkPhase);

		_attackTimeText.text = _atkSlider.value.ToString("f0");

		if (!death)
		{
			if (_currentTime <= _atkSlider.minValue)
			{
				Debug.Log($"{EnemyDataController.Instance.EnemySavePath[_id]}が攻撃！");
				_currentTime = _atkSlider.maxValue;
				var damage = EnemySaveData.Instance.EnemyAtk[_id] - CharacterSaveData.Instance.Def[0];

				if (damage <= 0)
				{
					Debug.Log($"{EnemyDataController.Instance.EnemySavePath[_id]}の攻撃が効かなかった");
				}
				else
				{
					var num = UnityEngine.Random.Range(0, TargetManager.Instance.CharacterDatas.Count);

					var damagetarget = TargetManager.Instance.CharacterDatas[num].GetComponent<IDamagable>();
					if (damagetarget != null)
					{
						TargetManager.Instance.CharacterDatas[num].GetComponent<IDamagable>().AddDamage(damage);
					}
				}
			}
			else
			{
				_currentTime -= Time.deltaTime;
			}

			_atkSlider.value = _currentTime;
		}

	}
}
