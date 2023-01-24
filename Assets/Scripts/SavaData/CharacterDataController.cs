using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDataController : MonoBehaviour
{
    public static CharacterDataController I = null;

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
        I = this;
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
                    _sp = _statusData.StatusDatas[i].Mp,
                    _atk = _statusData.StatusDatas[i].Atk,
                    _def = _statusData.StatusDatas[i].Def,
                    _agi = _statusData.StatusDatas[i].Agi,
                };
            }

            CharacterSaveData.I.SetValue(saveData, i);

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
                _name = CharacterSaveData.I.Name[i],
                _lv = CharacterSaveData.I.Lv[i],
                _hp = CharacterSaveData.I.Hp[i],
                _sp = CharacterSaveData.I.Sp[i],
                _atk = CharacterSaveData.I.Atk[i],
                _def = CharacterSaveData.I.Def[i],
                _agi = CharacterSaveData.I.Agi[i],
            };

            JsonSaveManager<CharacterData>.Save(saveData, _savePath[i]);
        }
    }
}
