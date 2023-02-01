using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenStatusPanel : MonoBehaviour, IPointerClickHandler
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
