using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCoinData : SingletonMonoBehaviour<GameCoinData>
{
    public int Coin => _coin;
    public int GachaCoin => _gachaCoin;

    [SerializeField]
    [Header("�����R�C��")]
    int _coin;

    [SerializeField]
    [Header("�����K�`���R�C��")]
    int _gachaCoin;

    string _coinKey;

    string _gachaCoinKey;

    private void Start()
    {
        //DontDestroyOnLoad(gameObject);

        //�L�[����ݒ�
        _coinKey = "COIN";
        _gachaCoinKey = "GACHA_COIN";

        //�����R�C���o�^
        _coin = PlayerPrefs.GetInt(_coinKey, 10000);
        _gachaCoin = PlayerPrefs.GetInt(_gachaCoinKey, 4500);

        Save(_coinKey, _coin);
        Load(_coinKey, _coin);
        Save(_gachaCoinKey, _gachaCoin);
        Load(_gachaCoinKey, _gachaCoin);
    }

    /// <summary>�R�C������ɓ��ꂽ��</summary>
    /// <param name="usedCoin">��ɓ��ꂽ�R�C��</param>
    public void AddCoin(int addCoin)
    {
        _coin += addCoin;
        Save(_coinKey, _coin);
        Load(_coinKey, _coin);
    }

    /// <summary>�K�`���R�C������ɓ��ꂽ��</summary>
    /// <param name="useGachaCoin">��ɓ��ꂽ�K�`���R�C��</param>
    public void AddGachaCoin(int addGachaCoin)
    {
        _gachaCoin += addGachaCoin;
        Save(_gachaCoinKey, _gachaCoin);
        Load(_gachaCoinKey, _gachaCoin);
    }

    /// <summary>�R�C�����g�p������</summary>
    /// <param name="usedCoin">�g�p����R�C��</param>
    public void UseCoin(int useCoin)
    {
        _coin -= useCoin;
        Save(_coinKey, _coin);
        Load(_coinKey, _coin);

        UIManager.Instance.GameCoin();
    }

    /// <summary>�K�`���R�C�����g�p������</summary>
    /// <param name="useGachaCoin">�g�p����K�`���R�C��</param>
    public void UseGachaCoin(int useGachaCoin)
    {
        _gachaCoin -= useGachaCoin;
        Save(_gachaCoinKey, _gachaCoin);
        Load(_gachaCoinKey, _gachaCoin);

        UIManager.Instance.GameCoin();
    }


    /// <summary>�f�[�^��ۑ�</summary>
    private void Save(string key, int data)
    {
        PlayerPrefs.SetInt(key, data);
        PlayerPrefs.Save();
    }

    /// <summary>�f�[�^��ǂݍ���</summary>
    private void Load(string key, int data)
    {
        data = PlayerPrefs.GetInt(key, data);
        PlayerPrefs.Save();
    }
}
