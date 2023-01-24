using System.Collections.Generic;
using UnityEngine;

public class EnemyDataController : MonoBehaviour
{
    public static EnemyDataController I = null;

    /// <summary>キャラクターステータスデータのパス名</summary>
    public List<string> EnemySavePath => _enemySavePath;

    [SerializeField]
    [Header("キャラクターデータのパス名")]
    List<string> _enemySavePath = new();

    [SerializeField]
    [Header("初期ステータス")]
    StatusData _enemyStatus;

    public void Start()
    {
        I = this;
        LoadingEnemyData();
    }

    public void EnemyRgister()
    {
        _enemySavePath = new();

        for (int i = 0; i < _enemyStatus.StatusDatas.Count; i++)
        {
            _enemySavePath.Add(_enemyStatus.StatusDatas[i].Name);
        }
    }

    /// <summary>セーブデータを読み込んで反映</summary>
    public void LoadingEnemyData()
    {
        for (int i = 0; i < _enemyStatus.StatusDatas.Count; i++)
        {
            EnemyData enemyData = JsonSaveManager<EnemyData>.Load(_enemySavePath[i]);

            if (enemyData == null)//セーブデータが存在しない場合は任意の値で初期化
            {
                //新たなセーブデータを作成
                enemyData = new EnemyData()
                {
                    _enemyName = _enemyStatus.StatusDatas[i].Name,
                    _enemyLv = _enemyStatus.StatusDatas[i].Lv,
                    _enemyHp = _enemyStatus.StatusDatas[i].Hp,
                    _enemyMp = _enemyStatus.StatusDatas[i].Mp,
                    _enemyAtk = _enemyStatus.StatusDatas[i].Atk,
                    _enemyDef = _enemyStatus.StatusDatas[i].Def,
                    _enemyAgi = _enemyStatus.StatusDatas[i].Agi,
                };
            }

            EnemySaveData.I.SetValueEnemyData(enemyData, i);
        }
    }

    private void OnApplicationQuit() //アプリケーション終了時に呼び出す
    {
        OverWriteEnemySaveData();
    }

    /// <summary>セーブデータの上書き</summary>
    public void OverWriteEnemySaveData()
    {
        for (int i = 0; i < _enemyStatus.StatusDatas.Count; i++)
        {
            EnemyData enemyData = new EnemyData()
            {
                _enemyName = EnemySaveData.I.EnemyName[i],
                _enemyLv = EnemySaveData.I.EnemyLv[i],
                _enemyHp = EnemySaveData.I.EnemyHp[i],
                _enemyMp = EnemySaveData.I.EnemyMp[i],
                _enemyAtk = EnemySaveData.I.EnemyAtk[i],
                _enemyDef = EnemySaveData.I.EnemyDef[i],
                _enemyAgi = EnemySaveData.I.EnemyAgi[i],
            };

            JsonSaveManager<EnemyData>.Save(enemyData, _enemySavePath[i]);
        }
    }
}
