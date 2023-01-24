using System.Collections.Generic;
using UnityEngine;

public class EnemyDataController : MonoBehaviour
{
    public static EnemyDataController I = null;

    /// <summary>�L�����N�^�[�X�e�[�^�X�f�[�^�̃p�X��</summary>
    public List<string> EnemySavePath => _enemySavePath;

    [SerializeField]
    [Header("�L�����N�^�[�f�[�^�̃p�X��")]
    List<string> _enemySavePath = new();

    [SerializeField]
    [Header("�����X�e�[�^�X")]
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

    /// <summary>�Z�[�u�f�[�^��ǂݍ���Ŕ��f</summary>
    public void LoadingEnemyData()
    {
        for (int i = 0; i < _enemyStatus.StatusDatas.Count; i++)
        {
            EnemyData enemyData = JsonSaveManager<EnemyData>.Load(_enemySavePath[i]);

            if (enemyData == null)//�Z�[�u�f�[�^�����݂��Ȃ��ꍇ�͔C�ӂ̒l�ŏ�����
            {
                //�V���ȃZ�[�u�f�[�^���쐬
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

    private void OnApplicationQuit() //�A�v���P�[�V�����I�����ɌĂяo��
    {
        OverWriteEnemySaveData();
    }

    /// <summary>�Z�[�u�f�[�^�̏㏑��</summary>
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
