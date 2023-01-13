using Ono.MVP.Model;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Cysharp.Threading.Tasks;
using System;

public class CharacterAtk : MonoBehaviour
{
    [SerializeField]
    Slider _atkSlider;

    float _currentTime;

    [SerializeField]
    [Header("キャラクターID")]
    int _id;

    [SerializeField]
    Text _damageText;

    bool _atkPhase;

    [SerializeField]
    Transform _createZone;
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
            Debug.Log("攻撃");

            _currentTime = _atkSlider.minValue;
            var damage = SaveCharacterData.I.Atk[_id] - SaveCharacterData.I.Def[3];
            EnemyModel.I.Damage(damage);
            _damageText.text = damage.ToString();
            Instantiate(_damageText, _createZone);

        }
        else
        {
            _currentTime += Time.deltaTime;
        }

        _atkSlider.value = _currentTime; 
    }
}
