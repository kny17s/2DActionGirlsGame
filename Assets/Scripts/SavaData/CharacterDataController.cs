using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDataController : SingletonMonoBehaviour<CharacterDataController>
{
    /// <summary>キャラクターステータスデータのパス名</summary>
    public List<string> SavePath => _savePath;

    [SerializeField]
    [Header("キャラクターデータのパス名")]
    List<string> _savePath = new();

    [SerializeField]
    [Header("初期ステータス")]
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

    /// <summary>セーブデータを読み込んで反映</summary>
    public void LoadingCharacterData()
    {
        for (int i = 0; i < _statusData.StatusDatas.Count; i++)
        {
            CharacterData saveData = JsonSaveManager<CharacterData>.Load(_savePath[i]);

            if (saveData == null)//セーブデータが存在しない場合は任意の値で初期化
            {
                //新たなセーブデータを作成
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

    private void OnApplicationQuit() //アプリケーション終了時に呼び出す
    {
        OverWriteSaveData();
    }

    /// <summary>セーブデータの上書き</summary>
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
