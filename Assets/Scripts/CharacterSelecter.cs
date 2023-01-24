using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelecter : MonoBehaviour
{
    public static CharacterSelecter I = null;

    public List<Sprite> CharacterSprite => _characterSprite;

    public List<int> CharaNum => _charaNum;

    [SerializeField]
    [Header("選択したキャラクター一覧")]
    List<Sprite> _characterSprite = new List<Sprite>();

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
        if (_characterSprite.Count == _partyMax)
        {
            Debug.Log("これ以上は追加できません");
        }
        if (_characterSprite.Count < _partyMax)
        {
            _characterSprite.Add(_characterMaterial[num]);
            _charaNum.Add(num);
            Instantiate(_charaPrefabs[num],_parentObject);
            if (_characterSprite.Count == _partyMax)
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
        if(_characterSprite.Count <= _partyMax)
        {
            _playButton.gameObject.SetActive(false);
            _characterSprite.Remove(_characterMaterial[num]);
            _charaNum.Remove(num);
        }
    }
}
