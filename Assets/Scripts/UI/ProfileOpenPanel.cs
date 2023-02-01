using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ProfileOpenPanel : MonoBehaviour,IPointerClickHandler
{
    [SerializeField]
    [Header("キャラクターID")]
    int _id;

    bool _chara = true;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_chara)
        {
            UIManager.I.OpenCharaProFilePanel(_id);
        }
    }
}
