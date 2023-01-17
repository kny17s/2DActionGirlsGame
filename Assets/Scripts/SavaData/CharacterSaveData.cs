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
    public int _sp;
}

public class CharacterSaveData : MonoBehaviour
{
    public static CharacterSaveData I = null;

    /// <summary>レベル</summary>
    public int[] Lv => _lv;

    /// <summary>スキルポイント</summary>
    public int[] Sp => _sp;

    /// <summary>素早さ</summary>
    public float[] Agi => _agi;

    /// <summary>防御力</summary>
    public float[] Def => _def;

    /// <summary>攻撃力</summary>
    public float[] Atk => _atk;

    /// <summary>体力</summary>
    public float[] Hp => _hp;

    /// <summary>キャラクター名</summary>
    public string[] Name => _name;

    [SerializeField]
    [Header("キャラクター名")]
    string[] _name;

    [SerializeField]
    [Header("キャラクターレベル")]
    int[] _lv;

    [SerializeField]
    [Header("キャラクターの体力")]
    float[] _hp;

    [SerializeField]
    [Header("キャラクターの魔力")]
    int[] _sp;

    [SerializeField]
    [Header("キャラクターの攻撃力")]
    float[] _atk;

    [SerializeField]
    [Header("キャラクターの防御力")]
    float[] _def;

    [SerializeField]
    [Header("キャラクターの攻撃速度")]
    float[] _agi;

    void Awake() => I = this;

    public void SetValue(CharacterData saveData, int id)
    {
        _name[id] = saveData._name;
        _lv[id] = saveData._lv;
        _hp[id] = saveData._hp;
        _atk[id] = saveData._atk;
        _def[id] = saveData._def;
        _agi[id] = saveData._agi;
        _sp[id] = saveData._sp;
    }

    /// <summary>レベルが上がった場合に反映</summary>
    /// <param name="lv">上がったレベル</param>
    /// <param name="id">キャラクターID</param>
    public void PlusLv(int lv, int id)
    {
        _lv[id] += lv;
    }

    /// <summary>体力が上がった場合に反映</summary>
    /// <param name="hp">上がった体力</param>
    /// <param name="id">キャラクターID</param>
    public void PlusHp(float hp, int id)
    {
        _hp[id] += hp;
    }

    /// <summary>攻撃が上がった場合に反映</summary>
    /// <param name="atk">上がったレベル</param>
    /// <param name="id">キャラクターID</param>
    public void PlusAtk(float atk, int id)
    {
        _atk[id] += atk;
    }

    /// <summary>防御力が上がった場合に反映</summary>
    /// <param name="def">上がったレベル</param>
    /// <param name="id">キャラクターID</param>
    public void PlusDef(float def, int id)
    {
        _hp[id] += def;
    }

    /// <summary>攻撃速度が上がった場合に反映</summary>
    /// <param name="agi">上がったレベル</param>
    /// <param name="id">キャラクターID</param>
    public void PlusAgi(float agi, int id)
    {
        _agi[id] += agi;
    }

    /// <summary>スキルポイントが増えた場合に反映</summary>
    /// <param name="Sp">上がったレベル</param>
    /// <param name="id">キャラクターID</param>
    public void PlusSp(int Sp, int id)
    {
        _sp[id] += Sp;
    }
}

