using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCoinData : SingletonMonoBehaviour<GameCoinData>
{
    public int Coin => _coin;
    public int GachaCoin => _gachaCoin;

    [SerializeField]
    [Header("所持コイン")]
    int _coin;

    [SerializeField]
    [Header("所持ガチャコイン")]
    int _gachaCoin;

    string _coinKey;

    string _gachaCoinKey;

    private void Start()
    {
        //DontDestroyOnLoad(gameObject);

        //キー名を設定
        _coinKey = "COIN";
        _gachaCoinKey = "GACHA_COIN";

        //初期コイン登録
        _coin = PlayerPrefs.GetInt(_coinKey, 10000);
        _gachaCoin = PlayerPrefs.GetInt(_gachaCoinKey, 4500);

        Save(_coinKey, _coin);
        Load(_coinKey, _coin);
        Save(_gachaCoinKey, _gachaCoin);
        Load(_gachaCoinKey, _gachaCoin);
    }

    /// <summary>コインを手に入れた時</summary>
    /// <param name="usedCoin">手に入れたコイン</param>
    public void AddCoin(int addCoin)
    {
        _coin += addCoin;
        Save(_coinKey, _coin);
        Load(_coinKey, _coin);
    }

    /// <summary>ガチャコインを手に入れた時</summary>
    /// <param name="useGachaCoin">手に入れたガチャコイン</param>
    public void AddGachaCoin(int addGachaCoin)
    {
        _gachaCoin += addGachaCoin;
        Save(_gachaCoinKey, _gachaCoin);
        Load(_gachaCoinKey, _gachaCoin);
    }

    /// <summary>コインを使用した時</summary>
    /// <param name="usedCoin">使用するコイン</param>
    public void UseCoin(int useCoin)
    {
        _coin -= useCoin;
        Save(_coinKey, _coin);
        Load(_coinKey, _coin);

        UIManager.Instance.GameCoin();
    }

    /// <summary>ガチャコインを使用した時</summary>
    /// <param name="useGachaCoin">使用するガチャコイン</param>
    public void UseGachaCoin(int useGachaCoin)
    {
        _gachaCoin -= useGachaCoin;
        Save(_gachaCoinKey, _gachaCoin);
        Load(_gachaCoinKey, _gachaCoin);

        UIManager.Instance.GameCoin();
    }


    /// <summary>データを保存</summary>
    private void Save(string key, int data)
    {
        PlayerPrefs.SetInt(key, data);
        PlayerPrefs.Save();
    }

    /// <summary>データを読み込み</summary>
    private void Load(string key, int data)
    {
        data = PlayerPrefs.GetInt(key, data);
        PlayerPrefs.Save();
    }
}
