using System.Collections.Generic;
using UnityEngine;

public class EnemySaveController : MonoBehaviour
{
    public static EnemySaveController I = null;

    /// <summary>�L�����N�^�[�X�e�[�^�X�f�[�^�̃p�X��</summary>
    public List<string> EnemySavePath => _enemySavePath;

    [SerializeField]
    [Header("�L�����N�^�[�f�[�^�̃p�X��")]
    List<string> _enemySavePath = new();

    [SerializeField]
    [Header("�����X�e�[�^�X")]
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


    /// <summary>�Z�[�u�f�[�^��ǂݍ���Ŕ��f</summary>
    public void LoadingEnemyData()
    {
        for (int i = 0; i < _enemyStatusData.StatusDatas.Count; i++)
        {
            EnemySaveData enemySaveData = JsonSaveManager<EnemySaveData>.Load(_enemySavePath[i]);

            if (enemySaveData == null)//�Z�[�u�f�[�^�����݂��Ȃ��ꍇ�͔C�ӂ̒l�ŏ�����
            {
                //�V���ȃZ�[�u�f�[�^���쐬
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

    private void OnApplicationQuit() //�A�v���P�[�V�����I�����ɌĂяo��
    {
        OverWriteEnemySaveData();
    }

    /// <summary>�Z�[�u�f�[�^�̏㏑��</summary>
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
