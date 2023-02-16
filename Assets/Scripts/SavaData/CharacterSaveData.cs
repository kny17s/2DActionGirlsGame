using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class CharacterData
{
    public string _name;
    public int _lv;
    public float _hp;
    public float _atk;
    public float _def;
    public float _agi;
    public int _mp;
}

public class CharacterSaveData : SingletonMonoBehaviour<CharacterSaveData>
{
    /// <summary>���x��</summary>
    public int[] Lv => _lv;

    /// <summary>�X�L���|�C���g</summary>
    public int[] Mp => _mp;

    /// <summary>�f����</summary>
    public float[] Agi => _agi;

    /// <summary>�h���</summary>
    public float[] Def => _def;

    /// <summary>�U����</summary>
    public float[] Atk => _atk;

    /// <summary>�̗�</summary>
    public float[] Hp => _hp;

    /// <summary>�L�����N�^�[��</summary>
    public string[] Name => _name;

    [SerializeField]
    [Header("�L�����N�^�[��")]
    string[] _name;

    [SerializeField]
    [Header("�L�����N�^�[���x��")]
    int[] _lv;

    [SerializeField]
    [Header("�L�����N�^�[�̗̑�")]
    float[] _hp;

    [SerializeField]
    [Header("�L�����N�^�[�̖���")]
    int[] _mp;

    [SerializeField]
    [Header("�L�����N�^�[�̍U����")]
    float[] _atk;

    [SerializeField]
    [Header("�L�����N�^�[�̖h���")]
    float[] _def;

    [SerializeField]
    [Header("�L�����N�^�[�̍U�����x")]
    float[] _agi;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SetValue(CharacterData saveData, int id)
    {
        _name[id] = saveData._name;
        _lv[id] = saveData._lv;
        _hp[id] = saveData._hp;
        _atk[id] = saveData._atk;
        _def[id] = saveData._def;
        _agi[id] = saveData._agi;
        _mp[id] = saveData._mp;
    }

    /// <summary>���x�����オ�����ꍇ�ɔ��f</summary>
    /// <param name="lv">�オ�������x��</param>
    /// <param name="id">�L�����N�^�[ID</param>
    public void PlusLv(int lv, int id)
    {
        _lv[id] += lv;
    }

    /// <summary>�̗͂��オ�����ꍇ�ɔ��f</summary>
    /// <param name="hp">�オ�����̗�</param>
    /// <param name="id">�L�����N�^�[ID</param>
    public void PlusHp(float hp, int id)
    {
        _hp[id] += hp;
    }

    /// <summary>�U�����オ�����ꍇ�ɔ��f</summary>
    /// <param name="atk">�オ�������x��</param>
    /// <param name="id">�L�����N�^�[ID</param>
    public void PlusAtk(float atk, int id)
    {
        _atk[id] += atk;
    }

    /// <summary>�h��͂��オ�����ꍇ�ɔ��f</summary>
    /// <param name="def">�オ�������x��</param>
    /// <param name="id">�L�����N�^�[ID</param>
    public void PlusDef(float def, int id)
    {
        _hp[id] += def;
    }

    /// <summary>�U�����x���オ�����ꍇ�ɔ��f</summary>
    /// <param name="agi">�オ�������x��</param>
    /// <param name="id">�L�����N�^�[ID</param>
    public void PlusAgi(float agi, int id)
    {
        _agi[id] -= agi;
    }

    /// <summary>�X�L���|�C���g���������ꍇ�ɔ��f</summary>
    /// <param name="mp">�オ�������x��</param>
    /// <param name="id">�L�����N�^�[ID</param>
    public void PlusMp(int mp, int id)
    {
        _mp[id] -= mp;
    }
}

