using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
  fileName = "CharaProfile",
  menuName = "ScriptableObject/CharaProfile ")]
public class CharaProfile : ScriptableObject
{
    /// <summary>�L�����ʃX�e�[�^�X</summary>
    public List<Profile> Profile => _profile;

    [SerializeField]
    [Header("�L�����ʃX�e�[�^�X�f�[�^")]
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
    [Header("���O")]
    string _name;

    [SerializeField]
    [Header("�a����")]
    string _birthday;

    [SerializeField]
    [Header("�g��")]
    string _size;

    [SerializeField]
    [Header("�D��")]
    string _like;
}
