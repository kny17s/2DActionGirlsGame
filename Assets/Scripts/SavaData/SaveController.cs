using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveController : MonoBehaviour
{
    public static SaveController I = null;

    /// <summary>キャラクターステータスデータのパス名</summary>
    public List<string> SavePath => _savePath;

    [SerializeField]
    [Header("キャラクターデータのパス名")]
    List<string> _savePath = new();

    [SerializeField]
    [Header("初期ステータス")]
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


    /// <summary>セーブデータを読み込んで反映</summary>
    public void LoadingCharacterData()
    {
        for (int i = 0; i < _statusData.StatusDatas.Count; i++)
        {
            SaveData saveData = JsonSaveManager<SaveData>.Load(_savePath[i]);

            if (saveData == null)//セーブデータが存在しない場合は任意の値で初期化
            {
                //新たなセーブデータを作成
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

    private void OnApplicationQuit() //アプリケーション終了時に呼び出す
    {
        OverWriteSaveData();
    }

    /// <summary>セーブデータの上書き</summary>
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
