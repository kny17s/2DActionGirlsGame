using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsableCharacter : MonoBehaviour
{
    public static UsableCharacter I = null;

    public List<int> CharaNum => _charaID;

    public GameObject[] GachaCharacter  => _gachaCharacter;

    public List<GameObject> HasCharacter => _hasCharacter;

    [SerializeField]
    [Header("キャラクターイメージ")]
    Sprite[] _characterMaterial;

    const int _partyMax = 5;

    [SerializeField]
    Transform _parentObject;

    [SerializeField]
    GameObject[] _charaPrefabs;

    [SerializeField]
    GameObject[] _selectChara;

    [SerializeField]
    List<int> _charaID = new();

    [SerializeField]
    Button _playButton;

    [SerializeField]
    Transform _parent;

    [SerializeField]
    Transform _charaSelectParent;

    [SerializeField]
    List<GameObject> _hasCharacter;

    [SerializeField]
    GameObject[] _gachaCharacter;

    [SerializeField]
    int[] _charaNum;

    [SerializeField]
    GameObject _gathaResultPanel;

    [SerializeField]
    Transform _gathaResultParent;

    [SerializeField]
    int _gathaNum = 10;

    [SerializeField]
    Button _resultClossButton;

    private void Awake()
    {
        I = this;
        DontDestroyOnLoad(this.gameObject);
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
            Instantiate(_charaPrefabs[num],_parentObject);
            if (_charaID.Count == _partyMax)
            {
                _playButton.gameObject.SetActive(true);
            }
            else
            {
                _playButton.gameObject.SetActive(false);
            }
        }
    }

    public void Reduction(int num)
    {
        if(_charaID.Count <= _partyMax)
        {
            _playButton.gameObject.SetActive(false);
            _charaID.Remove(num);
        }
    }

    public void GachaTen()
    {
        OpenGachaResultPanel();

        for(int i = 0; i < 10; i++)
        {
            var num = Random.Range(0, _gachaCharacter.Length);
            Debug.Log(num);
            if (!_hasCharacter.Contains(_gachaCharacter[num]))
            {
                _hasCharacter.Add(_gachaCharacter[num]);
                Instantiate(_gachaCharacter[num], _parent);
                Instantiate(_selectChara[num], _charaSelectParent);
                _gathaNum--;
            }
            else
            {
                Debug.Log($"ID：{num}のキャラが重複しました。");
                _charaNum[num]++;
            }
        }

        GachaResult(_gathaNum);
    }

    public void Gacha()
    {
        var num = Random.Range(0, _gachaCharacter.Length);
        Debug.Log(num);
        _hasCharacter.Add(_gachaCharacter[num]);
        Instantiate(_gachaCharacter[num], _parent);
    }


    public void OpenGachaResultPanel()
    {
        _gathaResultPanel.SetActive(true);
    }

    public async void GachaResult(int num)
    {
        await UniTask.Delay(System.TimeSpan.FromSeconds(0.5f));

        for (int i = num; i < 10; i++)
        {
            Instantiate(_hasCharacter[i - num], _gathaResultParent);
            await UniTask.Delay(System.TimeSpan.FromSeconds(1.0f));
        }

        _resultClossButton.gameObject.SetActive(true);
    }

    public void ClossGachaResultPanel()
    {
        _gathaResultPanel.SetActive(false);
        _resultClossButton.gameObject.SetActive(false);
        GetChildren(_gathaResultParent.gameObject);
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
