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

            if(damage <= 0)
            {
                Debug.Log($"{SaveController.I.SavePath[_id]}の攻撃が効かなかった");
            }
            else
            {
                EnemyModel.I.Damage(damage);
                CreateDamage.I.DamageText(damage);
            }
        }
        else
        {
            _currentTime += Time.deltaTime;
        }

        _atkSlider.value = _currentTime; 
    }
}
