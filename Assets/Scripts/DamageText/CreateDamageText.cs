using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDamageText : SingletonMonoBehaviour<CreateDamageText>
{
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

    /// <summary>敵が受けたダメージをテキストで生成</summary>
    /// <param name="damage">ダメージ量</param>
    public void EnemyDamageText(float damage, int id)
    {
        Instantiate(_damageText[0], _enemyTarget[id].transform.position + _enemyOffSet, transform.rotation).GetComponent<TextMesh>().text = damage.ToString();
    }

    /// <summary>味方が受けたダメージをテキストで生成</summary>
    /// <param name="damage">ダメージ量</param>
    public void CharacterDamageText(float damage, int id)
    {
        Instantiate(_damageText[1], _characterTarget[id].transform.position + _characterOffSet, transform.rotation).GetComponent<TextMesh>().text = damage.ToString();
    }

    /// <summary>味方が受けたダメージをテキストで生成</summary>
    /// <param name="damage">回復量</param>
    public void CharacterRecoveryText(float recovery, int id)
    {
        Instantiate(_damageText[2], _characterTarget[id].transform.position + _characterOffSet, transform.rotation).GetComponent<TextMesh>().text = recovery.ToString();
    }

}