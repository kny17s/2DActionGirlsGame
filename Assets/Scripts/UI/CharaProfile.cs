using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
  fileName = "CharaProfile",
  menuName = "ScriptableObject/CharaProfile ")]
public class CharaProfile : ScriptableObject
{
    /// <summary>キャラ別ステータス</summary>
    public List<Profile> Profile => _profile;

    [SerializeField]
    [Header("キャラ別ステータスデータ")]
    List<Profile> _profile = new List<Profile>();
}


[System.Serializable]
public class Profile
{
    public string Name => _name;

    public string Birthday => _birthday;

    public string Size => _size;

    public string Like => _like;

    [SerializeField]
    [Header("名前")]
    string _name;

    [SerializeField]
    [Header("誕生日")]
    string _birthday;

    [SerializeField]
    [Header("身長")]
    string _size;

    [SerializeField]
    [Header("好き")]
    string _like;
}
