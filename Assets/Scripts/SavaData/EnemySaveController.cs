using System.Collections.Generic;
using UnityEngine;

public class EnemySaveController : MonoBehaviour
{
    public static EnemySaveController I = null;

    /// <summary>キャラクターステータスデータのパス名</summary>
    public List<string> EnemySavePath => _enemySavePath;

    [SerializeField]
    [Header("キャラクターデータのパス名")]
    List<string> _enemySavePath = new();

    [SerializeField]
    [Header("初期ステータス")]
    StatusData _enemyStatusData;

    private void Start()
    {
        I = this;
        LoadingEnemyData();
    }

    public void EnemyRgister()
    {
        for (int i = 0; i < _enemyStatusData.StatusDatas.Count; i++)
        {
            _enemySavePath.Add(_enemyStatusData.StatusDatas[i].Name);
        }
    }

    public void EnemyUnRegister() => _enemySavePath = new();


    /// <summary>セーブデータを読み込んで反映</summary>
    public void LoadingEnemyData()
    {
        for (int i = 0; i < _enemyStatusData.StatusDatas.Count; i++)
        {
            EnemySaveData enemySaveData = JsonSaveManager<EnemySaveData>.Load(_enemySavePath[i]);

            if (enemySaveData == null)//セーブデータが存在しない場合は任意の値で初期化
            {
                //新たなセーブデータを作成
                enemySaveData = new EnemySaveData()
                {
                    _enemyName = _enemyStatusData.StatusDatas[i].Name,
                    _enemyLv = _enemyStatusData.StatusDatas[i].Lv,
                    _enemyHp = _enemyStatusData.StatusDatas[i].Hp,
                    _enemyMp = _enemyStatusData.StatusDatas[i].Mp,
                    _enemyAtk = _enemyStatusData.StatusDatas[i].Atk,
                    _enemyDef = _enemyStatusData.StatusDatas[i].Def,
                    _enemyMagicAtk = _enemyStatusData.StatusDatas[i].MagicAtk,
                    _enemyMagicDef = _enemyStatusData.StatusDatas[i].MagicDef,
                    _enemyAgi = _enemyStatusData.StatusDatas[i].Agi,
                };
            }

            SaveEnemyCharacterData.I.SetValueEnemyData(enemySaveData, i);

        }
    }

    private void OnApplicationQuit() //アプリケーション終了時に呼び出す
    {
        OverWriteEnemySaveData();
    }

    /// <summary>セーブデータの上書き</summary>
    public void OverWriteEnemySaveData()
    {
        for (int i = 0; i < _enemyStatusData.StatusDatas.Count; i++)
        {
            EnemySaveData enemySaveData = new EnemySaveData()
            {
                _enemyName = SaveEnemyCharacterData.I.EnemyName[i],
                _enemyLv = SaveEnemyCharacterData.I.EnemyLv[i],
                _enemyHp = SaveEnemyCharacterData.I.EnemyHp[i],
                _enemyMp = SaveEnemyCharacterData.I.EnemyMp[i],
                _enemyAtk = SaveEnemyCharacterData.I.EnemyAtk[i],
                _enemyDef = SaveEnemyCharacterData.I.EnemyDef[i],
                _enemyMagicAtk = SaveEnemyCharacterData.I.EnemyDef[i],
                _enemyMagicDef = SaveEnemyCharacterData.I.EnemyDef[i],
                _enemyAgi = SaveEnemyCharacterData.I.EnemyAgi[i],
            };

            JsonSaveManager<EnemySaveData>.Save(enemySaveData, _enemySavePath[i]);
        }
    }
}
