using UnityEngine;
using System;

[Serializable]
public class EnemySaveData
{
    public string _enemyName;
    public int _enemyLv;
    public float _enemyHp;
    public float _enemyAtk;
    public float _enemyDef;
    public float _enemyMagicAtk;
    public float _enemyMagicDef;
    public float _enemyAgi;
    public int _enemyMp;
}

public class SaveEnemyCharacterData : MonoBehaviour
{
    public static SaveEnemyCharacterData I = null;

    /// <summary>レベル</summary>
    public int[] EnemyLv => _enemyLv;

    /// <summary>マジックポイント</summary>
    public int[] EnemyMp => _enemyMp;

    /// <summary>素早さ</summary>
    public float[] EnemyAgi => _enemyAgi;

    /// <summary>防御力</summary>
    public float[] EnemyDef => _enemyDef;

    /// <summary>攻撃力</summary>
    public float[] EnemyAtk => _enemyAtk;

    /// <summary>体力</summary>
    public float[] EnemyHp => _enemyHp;

    /// <summary>キャラクター名</summary>
    public string[] EnemyName => _enemyName;

    [SerializeField]
    [Header("キャラクター名")]
    string[] _enemyName;

    [SerializeField]
    [Header("キャラクターレベル")]
    int[] _enemyLv;

    [SerializeField]
    [Header("キャラクターの体力")]
    float[] _enemyHp;

    [SerializeField]
    [Header("キャラクターの魔力")]
    int[] _enemyMp;

    [SerializeField]
    [Header("キャラクターの攻撃力")]
    float[] _enemyAtk;

    [SerializeField]
    [Header("キャラクターの特殊攻撃力")]
    float[] _enemyMagicAtk;

    [SerializeField]
    [Header("キャラクターの防御力")]
    float[] _enemyDef;

    [SerializeField]
    [Header("キャラクターの特殊防御力")]
    float[] _enemyMagicDef;

    [SerializeField]
    [Header("キャラクターの攻撃速度")]
    float[] _enemyAgi;

    void Awake() => I = this;

    public void SetValueEnemyData(EnemySaveData enemySaveData, int id)
    {
        _enemyName[id] = enemySaveData._enemyName;
        _enemyLv[id] = enemySaveData._enemyLv;
        _enemyHp[id] = enemySaveData._enemyHp;
        _enemyAtk[id] = enemySaveData._enemyAtk;
        _enemyDef[id] = enemySaveData._enemyDef;
        _enemyMagicAtk[id] = enemySaveData._enemyMagicAtk;
        _enemyMagicDef[id] = enemySaveData._enemyMagicDef;
        _enemyAgi[id] = enemySaveData._enemyAgi;
        _enemyMp[id] = enemySaveData._enemyMp;
    }
}
