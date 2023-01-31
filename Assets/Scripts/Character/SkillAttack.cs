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
            if(!_characterAttack.Skill)
            {
                switch (_character.Id)
                {
                    case 0:
                        Debug.Log("�X�L�����g�p���܂����B");
                        _characterAttack.UseAttackSkill();
                        break;
                    case 1:
                        Debug.Log("�X�L�����g�p���܂����B");
                        _characterAttack.UseRecoverySkill(CharacterSaveData.I.Atk[_character.Id]);
                        break;
                    case 2:
                        Debug.Log("�X�L�����g�p���܂����B");
                        _characterAttack.UseAttackSkill();
                        break;
                    case 3:
                        Debug.Log("�X�L�����g�p���܂����B");
                        _characterAttack.UseRecoverySkill(CharacterSaveData.I.Atk[_character.Id]);
                        break;
                    case 4:
                        Debug.Log("�X�L�����g�p���܂����B");
                        _characterAttack.UseAttackSkill();
                        break;
                    case 5:
                        Debug.Log("�X�L�����g�p���܂����B");
                        _characterAttack.UseRecoverySkill(CharacterSaveData.I.Atk[_character.Id]);
                        break;
                    case 6:
                        Debug.Log("�X�L�����g�p���܂����B");
                        _characterAttack.UseAttackSkill();
                        break;
                    case 7:
                        Debug.Log("�X�L�����g�p���܂����B");
                        _characterAttack.UseRecoverySkill(CharacterSaveData.I.Atk[_character.Id]);
                        break;
                    case 8:
                        Debug.Log("�X�L�����g�p���܂����B");
                        _characterAttack.UseAttackSkill();
                        break;
                    case 9:
                        Debug.Log("�X�L�����g�p���܂����B");
                        _characterAttack.UseRecoverySkill(CharacterSaveData.I.Atk[_character.Id]);
                        break;
                }

            }
            else
            {
                Debug.Log("�Q�[�W�����܂��Ă��܂���");
            }
        }
    }
}
