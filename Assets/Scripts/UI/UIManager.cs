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
    Image _charaImage;

    [SerializeField]
    GameObject _statusPanel;

    [SerializeField]
    Button _statusButton;

    [SerializeField]
    Text _lvText;

    [SerializeField]
    Text _hpText;

    [SerializeField]
    Text _atkText;

    [SerializeField]
    Text _defText;

    [SerializeField]
    Text _agiText;

    [SerializeField]
    Text _spText;

    int _id;
    public void Awake() => I = this;

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
        _charaImage.sprite = UsableCharacter.I.GachaCharacter[id].GetComponent<Image>().sprite;
        _id = id;
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

    public void OpenCharaStatusPanel()
    {
        _lvText.text = CharacterSaveData.I.Lv[_id].ToString("f0");
        _hpText.text = CharacterSaveData.I.Hp[_id].ToString("f0");
        _atkText.text = CharacterSaveData.I.Atk[_id].ToString("f0");
        _defText.text = CharacterSaveData.I.Def[_id].ToString("f0");
        _agiText.text = CharacterSaveData.I.Agi[_id].ToString("f0");
        _spText.text = CharacterSaveData.I.Sp[_id].ToString("f0");

        _statusPanel.SetActive(true);
    }

    public void TrainingButton()
    {

    }
    public void ClossCharaStatusButton()
    {
        _statusPanel.SetActive(false);
    }
}
