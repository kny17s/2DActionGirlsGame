using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour,IDamagable,IRecovery
{
	public Image CharaImage => _charaImage;

    public bool Death => _death;

    public int Id => _id;

    [SerializeField]
	[Header("キャラクターのHpSlider")]
	Slider _hpSlider;

	[SerializeField]
	[Header("キャラクターID")]
	int _id;

	float _currentHp;

	[SerializeField]
	Image _charaImage;

	[SerializeField]
	bool _death = false;

    async void Start()
	{
		_charaImage.color = Color.white;
		await UniTask.Delay(TimeSpan.FromSeconds(0.1f));

		_hpSlider.maxValue = CharacterSaveData.Instance.Hp[_id];
		_currentHp = _hpSlider.maxValue;
		_hpSlider.value = _currentHp;
	}

	/// <summary>ダメージを受けた時の処理</summary>
	/// <param name="damage">ダメージ量</param>
	public void AddDamage(float damage)
    {
		_currentHp -= damage;

		DOTween
			.To(() => _hpSlider.value,
			value => _hpSlider.value = value,
			_currentHp, 1.5f);

		Debug.Log("Hp: " + _currentHp);
		var num = UnityEngine.Random.Range(0,5);
		CreateDamageText.Instance.CharacterDamageText(damage, num);

		if (_hpSlider.value <= 0)
		{
			_charaImage.color = Color.gray;
			_death = true;
			Debug.Log($"{CharacterDataController.Instance.SavePath[_id]}のHpがなくなりました");
			BattleManager.Instance.CharacterDeathCheck();
		}
	}

    public void AddRecovery(float recovery, int id)
    {
		_currentHp += recovery;

		CreateDamageText.Instance.CharacterRecoveryText(recovery, id);

		DOTween
			.To(() => _hpSlider.value,
			value => _hpSlider.value = value,
			_currentHp, 1.5f);

		if (_currentHp >= _hpSlider.maxValue)
		{
			_currentHp = _hpSlider.value;
		}

		Debug.Log("Hp: " + _currentHp);
	}
}
