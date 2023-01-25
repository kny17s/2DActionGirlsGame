using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager I = null;

    [SerializeField]
    GameObject _charaSelectPanel;

    [SerializeField]
    GameObject _allCharaPanel;

    [SerializeField]
    GameObject _charaProfilePanel;

    [SerializeField]
    Text _nameText;

    [SerializeField]
    Text _sizeText;

    [SerializeField]
    Text _birthdayText;

    [SerializeField]
    Text _likeText;

    [SerializeField]
    CharaProfile _charaProfile;

    [SerializeField]
    GameObject _gachaPanel;

    [SerializeField]

    public void Awake()
    {
        if (I == null)
        {
            I = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void OpenPartySelectPanel()
    {
        _charaSelectPanel.SetActive(true);
    }

    public void ClosePartySelectPanel()
    {
        _charaSelectPanel.SetActive(false);
    }

    public void OpenAllCharaPanel()
    {
        _allCharaPanel.SetActive(true);
    }

    public void CloseAllCharaPanel()
    {
        _allCharaPanel.SetActive(false);
    }

    public void OpenCharaProFilePanel(int id)
    {
        _nameText.text = _charaProfile.Profile[id].Name;
        _sizeText.text = _charaProfile.Profile[id].Size;
        _birthdayText.text = _charaProfile.Profile[id].Birthday;
        _likeText.text = _charaProfile.Profile[id].Like;

        _charaProfilePanel.SetActive(true);
    }

    public void CloseCharaProFilePanel()
    {
        _charaProfilePanel.SetActive(false);
    }

    public void OpenGachaPanel()
    {
        _gachaPanel.SetActive(true);
    }

    public void CloseGachaPanel()
    {
        _gachaPanel.SetActive(false);
    }
}
