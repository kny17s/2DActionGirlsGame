using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveController : MonoBehaviour
{
    public static SaveController I = null;

    /// <summary>�L�����N�^�[�X�e�[�^�X�f�[�^�̃p�X��</summary>
    public List<string> SavePath => _savePath;

    [SerializeField]
    [Header("�L�����N�^�[�f�[�^�̃p�X��")]
    List<string> _savePath = new();

    [SerializeField]
    [Header("�����X�e�[�^�X")]
    StatusData _statusData;

    private void Awake()
    {
        I = this;
        LoadingCharacterData();
    }

    public void Rgister()
    {
        for (int i = 0; i < _statusData.StatusDatas.Count; i++)
        {
            _savePath.Add(_statusData.StatusDatas[i].Name);
        }
    }

    public void UnRegister() => _savePath = new();


    /// <summary>�Z�[�u�f�[�^��ǂݍ���Ŕ��f</summary>
    public void LoadingCharacterData()
    {
        for (int i = 0; i < _statusData.StatusDatas.Count; i++)
        {
            SaveData saveData = JsonSaveManager<SaveData>.Load(_savePath[i]);

            if (saveData == null)//�Z�[�u�f�[�^�����݂��Ȃ��ꍇ�͔C�ӂ̒l�ŏ�����
            {
                //�V���ȃZ�[�u�f�[�^���쐬
                saveData = new SaveData()
                {
                    _name = _statusData.StatusDatas[i].Name,
                    _lv = _statusData.StatusDatas[i].Lv,
                    _hp = _statusData.StatusDatas[i].Hp,
                    _mp = _statusData.StatusDatas[i].Mp,
                    _atk = _statusData.StatusDatas[i].Atk,
                    _def = _statusData.StatusDatas[i].Def,
                    _magicAtk = _statusData.StatusDatas[i].MagicAtk,
                    _magicDef = _statusData.StatusDatas[i].MagicDef,
                    _agi = _statusData.StatusDatas[i].Agi,
                };
            }

            SaveCharacterData.I.SetValue(saveData, i);

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
            SaveData saveData = new SaveData()
            {
                _name = SaveCharacterData.I.Name[i],
                _lv = SaveCharacterData.I.Lv[i],
                _hp = SaveCharacterData.I.Hp[i],
                _mp = SaveCharacterData.I.Mp[i],
                _atk = SaveCharacterData.I.Atk[i],
                _def = SaveCharacterData.I.Def[i],
                _magicAtk = SaveCharacterData.I.Def[i],
                _magicDef = SaveCharacterData.I.Def[i],
                _agi = SaveCharacterData.I.Agi[i],
            };

            JsonSaveManager<SaveData>.Save(saveData, _savePath[i]);
        }
    }
}
