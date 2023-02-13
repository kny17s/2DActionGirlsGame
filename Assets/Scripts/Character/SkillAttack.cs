using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkillAttack : MonoBehaviour, IPointerClickHandler
{
    CharacterAttack _characterAttack;
    Character _character;

    private void Start()
    {
        _characterAttack = gameObject.GetComponent<CharacterAttack>();
        _character = gameObject.GetComponent<Character>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _characterAttack.UseSkill();
    }
}
