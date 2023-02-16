using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

public class UIManager : SingletonMonoBehaviour<UIManager>
{
    public Transform ParentObject => _parentObject;
    public Transform Parent => _parent;
    public Button PlayButton => _playButton;
    public Button ResultClossButton => _resultClossButton; 
    public Transform GathaResultParent => _gathaResultParent;
    public GameObject GathaResultPanel => _gathaResultPanel;

    public Transform CharaSelectParent => _charaSelectParent;

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
    GameObject _maxStatusPanel;

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

    [SerializeField]
    Image _maxStatusCharaImage;

    [SerializeField]
    StatusData _maxStatusData;

    [SerializeField]
    GameObject _trainingPanel;

    [SerializeField]
    GameObject _currentStatusPanel;

    [SerializeField]
    Text _currentLvText;

    [SerializeField]
    Text _currentHpText;

    [SerializeField]
    Text _currentAtkText;

    [SerializeField]
    Text _currentDefText;

    [SerializeField]
    Text _currentAgiText;

    [SerializeField]
    Text _currentSpText;

    [SerializeField]
    Image _currentStatusCharaImage;

    [SerializeField]
    GameCoinData _gameCoinData;

    [SerializeField]
    Text _coinText;

    [SerializeField]
    Text _gachaCoinText;

    [SerializeField]
    GameObject _gathaResultPanel;

    [SerializeField]
    Transform _gathaResultParent;

    [SerializeField]
    Button _resultClossButton;

    [SerializeField]
    Button _playButton;

    [SerializeField]
    Transform _parent;

    [SerializeField]
    Transform _parentObject;

    [SerializeField]
    Transform _charaSelectParent;

    [SerializeField]
    Button _gachaButton;

    private void Start()
    {

        this.UpdateAsObservable()
            .Subscribe(_ => GameCoin())
            .AddTo(this);

        _gachaButton.OnPointerClickAsObservable()
            .Subscribe(_ => UsableCharacter.Instance.GachaTen())
            .AddTo(this);

        _resultClossButton.OnPointerClickAsObservable()
            .Subscribe(_ => UsableCharacter.Instance.ClossGachaResultPanel())
            .AddTo(this);

        UsableCharacter.Instance.LoadChara();
    }

    public void GameCoin()
    {
        _coinText.text = _gameCoinData.Coin.ToString();
        _gachaCoinText.text = _gameCoinData.GachaCoin.ToString();
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
        _charaImage.sprite = UsableCharacter.Instance.GachaCharacter[id].GetComponent<Image>().sprite;

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

    public void OpenCharaGachaStatusPanel(int id)
    {
        _lvText.text = _maxStatusData.StatusDatas[id].Lv.ToString("f0");
        _hpText.text = _maxStatusData.StatusDatas[id].Hp.ToString("f0");
        _atkText.text = _maxStatusData.StatusDatas[id].Atk.ToString("f0");
        _defText.text = _maxStatusData.StatusDatas[id].Def.ToString("f0");
        _agiText.text = _maxStatusData.StatusDatas[id].Agi.ToString("f0");
        _spText.text = _maxStatusData.StatusDatas[id].Mp.ToString("f0");

        _maxStatusCharaImage.sprite = UsableCharacter.Instance.GachaCharacter[id].GetComponent<Image>().sprite;
        _maxStatusPanel.SetActive(true);
    }

    public void OpenTrainingPanel()
    {
        _trainingPanel.SetActive(true);
    }

    public void CloseTrainingPanel()
    {
        _trainingPanel.SetActive(false);
    }


    public void CloseCharaMaxStatusButton()
    {
        _maxStatusPanel.SetActive(false);
    }

    public void OpenCharaStatusPanel(int id)
    {
        _currentLvText.text = CharacterSaveData.Instance.Lv[id].ToString("f0");
        _currentHpText.text = CharacterSaveData.Instance.Hp[id].ToString("f0");
        _currentAtkText.text = CharacterSaveData.Instance.Atk[id].ToString("f0");
        _currentDefText.text = CharacterSaveData.Instance.Def[id].ToString("f0");
        _currentAgiText.text = CharacterSaveData.Instance.Agi[id].ToString("f0");
        _currentSpText.text = CharacterSaveData.Instance.Mp[id].ToString("f0");

        _currentStatusCharaImage.sprite = UsableCharacter.Instance.GachaCharacter[id].GetComponent<Image>().sprite;
        _currentStatusPanel.SetActive(true);
    }

    public void CloseCharaStatusPanel()
    {
        _currentStatusPanel.SetActive(false);
    }

}
