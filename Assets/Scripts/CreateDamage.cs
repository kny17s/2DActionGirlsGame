using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDamage : MonoBehaviour
{
    public static CreateDamage I = null;

    [SerializeField]
    GameObject _damageText;

    [SerializeField]
    GameObject _target;

    [SerializeField]
    Vector3 _offSet;

    public void Awake() => I = this;

    /// <summary>�_���[�W�e�L�X�g�𐶐�</summary>
    /// <param name="damage">�_���[�W��</param>
    public void DamageText(float damage)
    {
        //                      �����ʒu(�{���Ȃ�G��transform.position)                            �������������e�L�X�g
        Instantiate(_damageText, _target.transform.position + _offSet, transform.rotation).GetComponent<TextMesh>().text = damage.ToString();
    }

}