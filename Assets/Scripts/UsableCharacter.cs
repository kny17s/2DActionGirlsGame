using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsableCharacter : MonoBehaviour
{
    public static UsableCharacter I = null;

    public List<int> CharaNum => _charaNum;

    [SerializeField]
    [Header("キャラクターイメージ")]
    Sprite[] _characterMaterial;

    const int _partyMax = 5;

    [SerializeField]
    Transform _parentObject;

    [SerializeField]
    GameObject[] _charaPrefabs;

    [SerializeField]
    List<int> _charaNum = new();

    [SerializeField]
    Button _playButton;

    [SerializeField]
    Transform _parent;

    [SerializeField]
    List<GameObject> _hasCharacter;

    [SerializeField]
    GameObject[] _gachaCharacter;

    private void Awake()
    {
        if (I == null)
        {
            I = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void AddCharacter(int num)
    {
        if (_charaNum.Count == _partyMax)
        {
            Debug.Log("これ以上は追加できません");
        }
        if (_charaNum.Count < _partyMax)
        {
            _charaNum.Add(num);
            Instantiate(_charaPrefabs[num],_parentObject);
            if (_charaNum.Count == _partyMax)
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
        if(_charaNum.Count <= _partyMax)
        {
            _playButton.gameObject.SetActive(false);
            _charaNum.Remove(num);
        }
    }

    public void GachaTen()
    {
        for(int i = 0; i < 10; i++)
        {
            var num = Random.Range(0, _gachaCharacter.Length);
            Debug.Log(num);
            _hasCharacter.Add(_gachaCharacter[num]);
            Instantiate(_gachaCharacter[num], _parent);
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
