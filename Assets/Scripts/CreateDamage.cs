using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDamage : MonoBehaviour
{
    public static CreateDamage I = null;

    [SerializeField]
    GameObject[] _damageText;

    [SerializeField]
    GameObject[] _enemyTarget;

    [SerializeField]
    GameObject[] _characterTarget;

    [SerializeField]
    Vector3 _enemyOffSet;

    [SerializeField]
    Vector3 _characterOffSet;

    public void Awake() => I = this;

    /// <summary>敵が受けたダメージをテキストで生成</summary>
    /// <param name="damage">ダメージ量</param>
    public void EnemyDamageText(float damage, int id)
    {
        //                      発生位置(本来なら敵のtransform.position)                            発生させたいテキスト
        Instantiate(_damageText[0], _enemyTarget[id].transform.position + _enemyOffSet, transform.rotation).GetComponent<TextMesh>().text = damage.ToString();
    }

    /// <summary>味方が受けたダメージをテキストで生成</summary>
    /// <param name="damage">ダメージ量</param>
    public void CharacterDamageText(float damage, int id)
    {
        //                      発生位置(本来なら敵のtransform.position)                            発生させたいテキスト
        Instantiate(_damageText[1], _characterTarget[id].transform.position + _characterOffSet, transform.rotation).GetComponent<TextMesh>().text = damage.ToString();
    }

}