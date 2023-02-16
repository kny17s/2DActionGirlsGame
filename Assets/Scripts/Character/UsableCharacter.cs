using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class UsableCharacter : SingletonMonoBehaviour<UsableCharacter>
{
    public List<int> CharaNum => _charaID;

    public GameObject[] GachaCharacter  => _gachaCharacter;

    public List<GameObject> HasCharacter => _hasCharacter;

    [SerializeField]
    [Header("キャラクターイメージ")]
    Sprite[] _characterMaterial;

    const int _partyMax = 5;

    const int USE_GACHACOIN = 1500;

    [SerializeField]
    GameObject[] _charaPrefabs;

    [SerializeField]
    GameObject[] _selectChara;

    [SerializeField]
    List<int> _charaID = new();

    [SerializeField]
    List<GameObject> _hasCharacter;

    [SerializeField]
    GameObject[] _gachaCharacter;

    [SerializeField]
    int[] _charaNum;

    int _gathaNum = 10;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void LoadChara()
    {
        _charaID = new();

        for (int i = 0; i < 10; i++)
        {
            if(_charaNum[i] >= 1)
            {
                Instantiate(_gachaCharacter[i], UIManager.Instance.Parent);
                Instantiate(_selectChara[i], UIManager.Instance.CharaSelectParent);
            }
        }
    }

    public void AddCharacter(int num)
    {
        if (_charaID.Count == _partyMax)
        {
            Debug.Log("これ以上は追加できません");
        }

        if (_charaID.Count < _partyMax)
        {
            _charaID.Add(num);
            Instantiate(_charaPrefabs[num], UIManager.Instance.ParentObject);
            if (_charaID.Count == _partyMax)
            {
                UIManager.Instance.PlayButton.gameObject.SetActive(true);
            }
            else
            {
                UIManager.Instance.PlayButton.gameObject.SetActive(false);
            }
        }
    }

    public void Reduction(int num)
    {
        if(_charaID.Count <= _partyMax)
        {
            UIManager.Instance.PlayButton.gameObject.SetActive(false);
            _charaID.Remove(num);
        }
    }

    public void GachaTen()
    {
        if(GameCoinData.Instance.GachaCoin < USE_GACHACOIN)
        {
            Debug.Log("足りないよ");
        }
        else
        {
            GameCoinData.Instance.UseGachaCoin(1500);

            for (int i = 0; i < 10; i++)
            {
                var num = Random.Range(0, _gachaCharacter.Length);
                Debug.Log(num);

                if (!_hasCharacter.Contains(_gachaCharacter[num]))
                {
                    _hasCharacter.Add(_gachaCharacter[num]);
                    Instantiate(_gachaCharacter[num], UIManager.Instance.Parent);
                    Instantiate(_selectChara[num], UIManager.Instance.CharaSelectParent);
                    _gathaNum--;
                    _charaNum[num]++;
                }
                else
                {
                    Debug.Log($"ID：{num}のキャラが重複しました。");
                    _charaNum[num]++;
                    CharacterDataController.Instance.PlusAllStatus(num);
                }
            }

            Debug.Log(_gathaNum);

            GachaResult(_gathaNum);
        }
    }

    public void Gacha()
    {
        OpenGachaResultPanel();

        var num = Random.Range(0, _gachaCharacter.Length);
        Debug.Log(num);

        if (!_hasCharacter.Contains(_gachaCharacter[num]))
        {
            _hasCharacter.Add(_gachaCharacter[num]);
            Instantiate(_gachaCharacter[num], UIManager.Instance.Parent);
            Instantiate(_selectChara[num], UIManager.Instance.CharaSelectParent);
            _gathaNum--;
        }
        else
        {
            Debug.Log($"ID：{num}のキャラが重複しました。");
            _charaNum[num]++;
        }

        GachaResult(_gathaNum);
    }

    public void OpenGachaResultPanel()
    {
        UIManager.Instance.GathaResultPanel.SetActive(true);
    }

    public async void GachaResult(int num)
    {
        OpenGachaResultPanel();

        await UniTask.Delay(System.TimeSpan.FromSeconds(0.5f));

        for (int i = num; i < 10; i++)
        {
            Instantiate(_hasCharacter[i - num], UIManager.Instance.GathaResultParent);
            await UniTask.Delay(System.TimeSpan.FromSeconds(1.0f));
        }

        UIManager.Instance.ResultClossButton.gameObject.SetActive(true);
    }

    public void ClossGachaResultPanel()
    {
        UIManager.Instance.GathaResultPanel.SetActive(false);
        UIManager.Instance.ResultClossButton.gameObject.SetActive(false);
        GetChildren(UIManager.Instance.GathaResultParent.gameObject);
    }


    public void GetChildren(GameObject obj)
    {
        Transform children = obj.GetComponentInChildren<Transform>();
        //子要素がいなければ終了
        if (children.childCount == 0)
        {
            return;
        }

        foreach (Transform childobj in children)
        {
            Destroy(childobj.gameObject);
        }
    }
}
