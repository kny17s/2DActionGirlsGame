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

    /// <summary>���x��</summary>
    public int[] EnemyLv => _enemyLv;

    /// <summary>�}�W�b�N�|�C���g</summary>
    public int[] EnemyMp => _enemyMp;

    /// <summary>�f����</summary>
    public float[] EnemyAgi => _enemyAgi;

    /// <summary>�h���</summary>
    public float[] EnemyDef => _enemyDef;

    /// <summary>�U����</summary>
    public float[] EnemyAtk => _enemyAtk;

    /// <summary>�̗�</summary>
    public float[] EnemyHp => _enemyHp;

    /// <summary>�L�����N�^�[��</summary>
    public string[] EnemyName => _enemyName;

    [SerializeField]
    [Header("�L�����N�^�[��")]
    string[] _enemyName;

    [SerializeField]
    [Header("�L�����N�^�[���x��")]
    int[] _enemyLv;

    [SerializeField]
    [Header("�L�����N�^�[�̗̑�")]
    float[] _enemyHp;

    [SerializeField]
    [Header("�L�����N�^�[�̖���")]
    int[] _enemyMp;

    [SerializeField]
    [Header("�L�����N�^�[�̍U����")]
    float[] _enemyAtk;

    [SerializeField]
    [Header("�L�����N�^�[�̖h���")]
    float[] _enemyDef;

    [SerializeField]
    [Header("�L�����N�^�[�̍U�����x")]
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
