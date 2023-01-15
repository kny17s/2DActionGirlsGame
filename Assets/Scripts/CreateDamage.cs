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

    /// <summary>ダメージテキストを生成</summary>
    /// <param name="damage">ダメージ量</param>
    public void DamageText(float damage)
    {
        //                      発生位置(本来なら敵のtransform.position)                            発生させたいテキスト
        Instantiate(_damageText, _target.transform.position + _offSet, transform.rotation).GetComponent<TextMesh>().text = damage.ToString();
    }

}