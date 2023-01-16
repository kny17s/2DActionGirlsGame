using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDamage : MonoBehaviour
{
    public static CreateDamage I = null;

    [SerializeField]
    GameObject _damageText;

    [SerializeField]
    GameObject[] _enemyTarget;

    [SerializeField]
    GameObject[] _characterTarget;

    [SerializeField]
    Vector3 _offSet;

    public void Awake() => I = this;

    /// <summary>�G���󂯂��_���[�W���e�L�X�g�Ő���</summary>
    /// <param name="damage">�_���[�W��</param>
    public void EnemyDamageText(float damage, int id)
    {
        //                      �����ʒu(�{���Ȃ�G��transform.position)                            �������������e�L�X�g
        Instantiate(_damageText, _enemyTarget[id].transform.position + _offSet, transform.rotation).GetComponent<TextMesh>().text = damage.ToString();
    }

    /// <summary>�������󂯂��_���[�W���e�L�X�g�Ő���</summary>
    /// <param name="damage">�_���[�W��</param>
    public void CharacterDamageText(float damage, int id)
    {
        //                      �����ʒu(�{���Ȃ�G��transform.position)                            �������������e�L�X�g
        Instantiate(_damageText, _characterTarget[id].transform.position + _offSet, transform.rotation).GetComponent<TextMesh>().text = damage.ToString();
    }

}