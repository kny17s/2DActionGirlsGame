using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDataController : SingletonMonoBehaviour<CharacterDataController>
{
    /// <summary>�L�����N�^�[�X�e�[�^�X�f�[�^�̃p�X��</summary>
    public List<string> SavePath => _savePath;

    [SerializeField]
    [Header("�L�����N�^�[�f�[�^�̃p�X��")]
    List<string> _savePath = new();

    [SerializeField]
    [Header("�����X�e�[�^�X")]
    StatusData _statusData;

    public void Start()
    {
        LoadingCharacterData();
    }

    public void Rgister()
    {
        _savePath = new();

        for (int i = 0; i < _statusData.StatusDatas.Count; i++)
        {
            _savePath.Add(_statusData.StatusDatas[i].Name);
        }
    }

    /// <summary>�Z�[�u�f�[�^��ǂݍ���Ŕ��f</summary>
    public void LoadingCharacterData()
    {
        for (int i = 0; i < _statusData.StatusDatas.Count; i++)
        {
            CharacterData saveData = JsonSaveManager<CharacterData>.Load(_savePath[i]);

            if (saveData == null)//�Z�[�u�f�[�^�����݂��Ȃ��ꍇ�͔C�ӂ̒l�ŏ�����
            {
                //�V���ȃZ�[�u�f�[�^���쐬
                saveData = new CharacterData()
                {
                    _name = _statusData.StatusDatas[i].Name,
                    _lv = _statusData.StatusDatas[i].Lv,
                    _hp = _statusData.StatusDatas[i].Hp,
                    _mp = _statusData.StatusDatas[i].Mp,
                    _atk = _statusData.StatusDatas[i].Atk,
                    _def = _statusData.StatusDatas[i].Def,
                    _agi = _statusData.StatusDatas[i].Agi,
                };
            }

            CharacterSaveData.Instance.SetValue(saveData, i);

        }
    }

    private void OnApplicationQuit() //�A�v���P�[�V�����I�����ɌĂяo��
    {
        OverWriteSaveData();
    }

    /// <summary>�Z�[�u�f�[�^�̏㏑��</summary>
    public void OverWriteSaveData()
    {
        for (int i = 0; i < _statusData.StatusDatas.Count; i++)
        {
            CharacterData saveData = new CharacterData()
            {
                _name = CharacterSaveData.Instance.Name[i],
                _lv = CharacterSaveData.Instance.Lv[i],
                _hp = CharacterSaveData.Instance.Hp[i],
                _mp = CharacterSaveData.Instance.Mp[i],
                _atk = CharacterSaveData.Instance.Atk[i],
                _def = CharacterSaveData.Instance.Def[i],
                _agi = CharacterSaveData.Instance.Agi[i],
            };

            JsonSaveManager<CharacterData>.Save(saveData, _savePath[i]);
        }
    }
}
