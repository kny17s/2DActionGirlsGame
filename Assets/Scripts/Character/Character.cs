using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour,IDamagable
{
	public static Character I = null;
	public Image CharaImage => _charaImage;

	[SerializeField]
	[Header("キャラクターのHpSlider")]
	Slider _hpSlider;

	[SerializeField]
	[Header("キャラクターID")]
	int _id;

	float _currentHp;

	[SerializeField]
	Image _charaImage;

    async void Start()
	{
		I = this;
		await UniTask.Delay(TimeSpan.FromSeconds(0.1f));

		_hpSlider.maxValue = CharacterSaveData.I.Hp[_id];
		_currentHp = _hpSlider.maxValue;
		_hpSlider.value = _currentHp;
	}

	/// <summary>ダメージを受けた時の処理</summary>
	/// <param name="damage">ダメージ量</param>
	public void AddDamage(float damage)
    {
		_currentHp -= damage;
		_hpSlider.value = _currentHp;
		Debug.Log("Hp: " + _hpSlider.value);
		var num = UnityEngine.Random.Range(0,5);
		CreateDamage.I.CharacterDamageText(damage, num);
		if (_hpSlider.value <= 0)
		{
			_charaImage.color = Color.gray;
			Debug.Log($"{CharacterDataController.I.SavePath[_id]}のHpがなくなりました");
		}
	}
}
