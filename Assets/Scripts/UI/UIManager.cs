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
}
