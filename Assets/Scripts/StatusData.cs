using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
  fileName = "StatusData",
  menuName = "ScriptableObject/StatusData")]
public class StatusData : ScriptableObject
{
    /// <summary>�L�����ʃX�e�[�^�X</summary>
    public List<StatusDatas> StatusDatas => _statusDatas;

    [SerializeField]
    [Header("�L�����ʃX�e�[�^�X�f�[�^")]
    List<StatusDatas> _statusDatas = new List<StatusDatas>();
}

[System.Serializable]
public class StatusDatas
{
    /// <summary>���x��</summary>
    public int Lv => _lv;

    /// <summary>�}�W�b�N�|�C���g</summary>
    public int Mp => _mp;

    /// <summary>�f����</summary>
    public float Agi => _agi;

    /// <summary>�h���</summary>
    public float Def => _def;

    /// <summary>�̗�</summary>
    public float MagicAtk => _magicAtk;

    /// <summary>�̗�</summary>
    public float MagicDef => _magicDef;

    /// <summary>�U����</summary>
    public float Atk => _atk;

    /// <summary>�̗�</summary>
    public float Hp => _hp;

    /// <summary>�L�����N�^�[��</summary>
    public string Name => _name;

    [SerializeField]
    [Header("�L�����N�^�[��")]
    string _name;

    [SerializeField]
    [Header("�L�����N�^�[���x��")]
    int _lv;

    [SerializeField]
    [Header("�L�����N�^�[�̗̑�")]    float _hp;

    [SerializeField]
    [Header("�L�����N�^�[�̖���")]
    int _mp;

    [SerializeField]
    [Header("�L�����N�^�[�̍U����")]
    float _atk;

    [SerializeField]
    [Header("�L�����N�^�[�̓���U����")]
    float _magicAtk;

    [SerializeField]
    [Header("�L�����N�^�[�̖h���")]
    float _def;

    [SerializeField]
    [Header("�L�����N�^�[�̓���h���")]
    float _magicDef;

    [SerializeField]
    [Header("�L�����N�^�[�̍U�����x")]
    float _agi;
}

