using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsableCharacter : MonoBehaviour
{
    public static UsableCharacter I = null;

    public List<int> CharaNum => _charaID;

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
        for(int i = 0; i < 10; i++)
        {
            var num = Random.Range(0, _gachaCharacter.Length);
            Debug.Log(num);
            if (!_hasCharacter.Contains(_gachaCharacter[num]))
            {
                _hasCharacter.Add(_gachaCharacter[num]);
                Instantiate(_gachaCharacter[num], _parent);
                Instantiate(_selectChara[num], _charaSelectParent);
            }
            else
            {
                Debug.Log($"ID：{num}のキャラが重複しました。");
                _charaNum[num]++;
            }
        }
    }

    public void Gacha()
    {
        var num = Random.Range(0, _gachaCharacter.Length);
        Debug.Log(num);
        _hasCharacter.Add(_gachaCharacter[num]);
        Instantiate(_gachaCharacter[num], _parent);
    }
}
