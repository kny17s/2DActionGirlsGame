using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkillAttack : MonoBehaviour, IPointerClickHandler
{

    CharacterAttack _characterAttack;
    Character _character;


    public void Start()
    {
        _characterAttack = this.gameObject.GetComponent<CharacterAttack>();
        _character = this.gameObject.GetComponent<Character>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!_character.Death)
        {
            Debug.Log("押せた");
            if (_characterAttack.Skill)
            {
                Debug.Log("スキルを使用しました。");
                _characterAttack.UseSkill();
            }
            else
            {
                Debug.Log("ゲージがたまっていません");
            }
        }
    }
}
