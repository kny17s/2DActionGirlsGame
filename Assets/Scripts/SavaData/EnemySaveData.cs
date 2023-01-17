using UnityEngine;
using System;

[Serializable]
public class EnemyData
{
    public string _enemyName;
    public int _enemyLv;
    public float _enemyHp;
    public float _enemyAtk;
    public float _enemyDef;
    public float _enemyAgi;
    public int _enemyMp;
}

public class EnemySaveData : MonoBehaviour
{
    public static EnemySaveData I = null;

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
    [Header("キャラクターの防御力")]
    float[] _enemyDef;

    [SerializeField]
    [Header("キャラクターの攻撃速度")]
    float[] _enemyAgi;

    void Awake() => I = this;

    public void SetValueEnemyData(EnemyData enemySaveData, int id)
    {
        _enemyName[id] = enemySaveData._enemyName;
        _enemyLv[id] = enemySaveData._enemyLv;
        _enemyHp[id] = enemySaveData._enemyHp;
        _enemyAtk[id] = enemySaveData._enemyAtk;
        _enemyDef[id] = enemySaveData._enemyDef;
        _enemyAgi[id] = enemySaveData._enemyAgi;
        _enemyMp[id] = enemySaveData._enemyMp;
    }
}
