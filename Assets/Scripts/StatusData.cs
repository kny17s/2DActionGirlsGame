using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
  fileName = "StatusData",
  menuName = "ScriptableObject/StatusData")]
public class StatusData : ScriptableObject
{
    /// <summary>キャラ別ステータス</summary>
    public List<StatusDatas> StatusDatas => _statusDatas;

    [SerializeField]
    [Header("キャラ別ステータスデータ")]
    List<StatusDatas> _statusDatas = new List<StatusDatas>();
}

[System.Serializable]
public class StatusDatas
{
    /// <summary>レベル</summary>
    public int Lv => _lv;

    /// <summary>マジックポイント</summary>
    public int Mp => _mp;

    /// <summary>素早さ</summary>
    public float Agi => _agi;

    /// <summary>防御力</summary>
    public float Def => _def;

    /// <summary>体力</summary>
    public float MagicAtk => _magicAtk;

    /// <summary>体力</summary>
    public float MagicDef => _magicDef;

    /// <summary>攻撃力</summary>
    public float Atk => _atk;

    /// <summary>体力</summary>
    public float Hp => _hp;

    /// <summary>キャラクター名</summary>
    public string Name => _name;

    [SerializeField]
    [Header("キャラクター名")]
    string _name;

    [SerializeField]
    [Header("キャラクターレベル")]
    int _lv;

    [SerializeField]
    [Header("キャラクターの体力")]    float _hp;

    [SerializeField]
    [Header("キャラクターの魔力")]
    int _mp;

    [SerializeField]
    [Header("キャラクターの攻撃力")]
    float _atk;

    [SerializeField]
    [Header("キャラクターの特殊攻撃力")]
    float _magicAtk;

    [SerializeField]
    [Header("キャラクターの防御力")]
    float _def;

    [SerializeField]
    [Header("キャラクターの特殊防御力")]
    float _magicDef;

    [SerializeField]
    [Header("キャラクターの攻撃速度")]
    float _agi;
}

